using BookStoreProjectCore;
using BookStoreProjectCore.IdentityAuth;
using BookStoreProjectCore.Logging;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BookStoreProjectAPI.Extentions
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly bool _isRequestResponseLoggingEnabled;

        public LoggingMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _isRequestResponseLoggingEnabled = config.GetValue<bool>("EnableRequestResponseLogging", true); // true is set manually, it was false idk why
        }

        public async Task InvokeAsync(HttpContext httpContext, BookStoreDbContext dbContext)
        {
            // Middleware is enabled only when the EnableRequestResponseLogging config value is set.  
            string[] url = httpContext.Request.Path.ToString().Split('/');

            if (_isRequestResponseLoggingEnabled && !(url[^1] == "Login"))
            {
                string callingUserId = "Unauthorized";

                if (httpContext.User.Identity.IsAuthenticated)
                {
                     callingUserId = dbContext.Users.FirstOrDefault(i => i.UserName == httpContext.User.Identity.Name).Id;
                }

                // LOG DATA TO EXTRACT
                var path = httpContext.Request.Path;
                var status = httpContext.Response.StatusCode;
                DateTime time = DateTime.UtcNow;

                string requestBodyText;

                if (httpContext.Request.QueryString.HasValue)
                {
                    requestBodyText = httpContext.Request.QueryString.Value.ToString();
                }
                else
                {
                    /*var originalRequestBody = httpContext.Response.Body;
                    using var newRequestBody = new MemoryStream();
                    httpContext.Request.Body = newRequestBody;

                    newRequestBody.Seek(0, SeekOrigin.Begin);
                    requestBodyText = await new StreamReader(httpContext.Request.Body).ReadToEndAsync();*/

                    requestBodyText = await ReadBodyFromRequest(httpContext.Request);

                }
                // LOG DATA TO EXTRACT

                // Temporarily replace the HttpResponseStream, which is a write-only stream, with a MemoryStream to capture it's value in-flight.  
                var originalResponseBody = httpContext.Response.Body;
                using var newResponseBody = new MemoryStream();
                httpContext.Response.Body = newResponseBody;

                // Call the next middleware in the pipeline  
                await _next(httpContext);

                newResponseBody.Seek(0, SeekOrigin.Begin);
                var responseBodyText = await new StreamReader(httpContext.Response.Body).ReadToEndAsync();

                LogTable logTable = new()
                {
                    LoggedUserId = callingUserId,
                    LogUploadTime = time.ToString(),
                    RequestJson = requestBodyText,
                    ResponseJson = responseBodyText,
                    Status = status,
                    RequestPath = path
                };

                await dbContext.Logs.AddAsync(logTable);
                await dbContext.SaveChangesAsync();

                Console.WriteLine($"HTTP FULL INFO:\n" +
                    $"\tLogUploadTime: {logTable.LogUploadTime}\n" +
                    $"\tRequestJson: {logTable.RequestJson}\n" +
                    $"\tResponseJson: {logTable.ResponseJson}\n" +
                    $"\tStatus: {logTable.Status}\n" +
                    $"\tUserId: {callingUserId}\n" +
                    $"\tRequestPath: {logTable.RequestPath}");

            newResponseBody.Seek(0, SeekOrigin.Begin);
                await newResponseBody.CopyToAsync(originalResponseBody);
            }
            else
            {
                await _next(httpContext);
            }
        }

        private static string FormatHeaders(IHeaderDictionary headers) => string.Join(", ", headers.Select(kvp => $"{kvp.Key}: {string.Join(", ", kvp.Value)}")); 

        private static async Task<string> ReadBodyFromRequest(HttpRequest request)
        {
            // Ensure the request's body can be read multiple times (for the next middlewares in the pipeline).  
            request.EnableBuffering();

            using var streamReader = new StreamReader(request.Body, leaveOpen: true);
            var requestBody = await streamReader.ReadToEndAsync();

            // Reset the request's body stream position for next middleware in the pipeline.  
            request.Body.Position = 0;
            return requestBody;
        }

    }
}
