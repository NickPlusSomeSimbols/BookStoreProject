using BookStoreProjectCore;
using BookStoreProjectCore.IdentityAuth;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BookStoreProjectAPI.Extentions
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly bool _isRequestResponseLoggingEnabled;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoggingMiddleware(RequestDelegate next, IConfiguration config/*, UserManager<ApplicationUser> userManager*/)
        {
            _next = next;
            _isRequestResponseLoggingEnabled = config.GetValue<bool>("EnableRequestResponseLogging", true); // true is set manually, it was false idk why
            /*_userManager = userManager;*/
        }

        public async Task InvokeAsync(HttpContext httpContext, BookStoreDbContext dbContext)
        {
            // Middleware is enabled only when the EnableRequestResponseLogging config value is set.  
            if (_isRequestResponseLoggingEnabled)
            {
                Console.WriteLine($"HTTP request information:\n" +
                    $"\tMethod: {httpContext.Request.Method}\n" +
                    $"\tPath: {httpContext.Request.Path}\n" +
                    $"\tQueryString: {httpContext.Request.QueryString}\n" +
                    $"\tHeaders: {FormatHeaders(httpContext.Request.Headers)}\n" +
                    $"\tSchema: {httpContext.Request.Scheme}\n" +
                    $"\tHost: {httpContext.Request.Host}\n" +
                    $"\tBody: {await ReadBodyFromRequest(httpContext.Request)}\n" +
                    $"\tBody: {httpContext.Request.Body.ToString}\n" +
                    $"\tTime: {DateTime.UtcNow}\n" +

                    $"\tNewBody: {httpContext.Request.QueryString.Value}\n" +
                    $"\tPath: {httpContext.Request.Path}");
                var user = new HttpContextAccessor().HttpContext?.User;

                /*using (var scope = app.ApplicationServices.CreateScope())
                {
                    //Resolve ASP .NET Core Identity with DI help
                    var userManager = (UserManager<ApplicationUser>)scope.ServiceProvider.GetService(typeof(UserManager<ApplicationUser>));
                    // do you things here
                }
                if (user.Identity.IsAuthenticated)
                {
                    Console.WriteLine("IsAuthenticated!!!");
                }
                else
                {
                    Console.WriteLine("NotAuthenticated!!!");
                }
*/
                // LOG DATA TO EXTRACT
                var path = httpContext.Request.Path;
                var status = httpContext.Response.StatusCode;
                DateTime time = DateTime.UtcNow;
                var requestBody = httpContext.Request.QueryString.Value;
                // LOG DATA TO EXTRACT

                // Temporarily replace the HttpResponseStream, which is a write-only stream, with a MemoryStream to capture it's value in-flight.  
                var originalResponseBody = httpContext.Response.Body;
                using var newResponseBody = new MemoryStream();
                httpContext.Response.Body = newResponseBody;

                // Call the next middleware in the pipeline  
                await _next(httpContext);

                newResponseBody.Seek(0, SeekOrigin.Begin);
                var responseBodyText = await new StreamReader(httpContext.Response.Body).ReadToEndAsync();

                Console.WriteLine($"HTTP response information:\n" +
                    $"\tStatusCode: {httpContext.Response.StatusCode}\n" +
                    $"\tContentType: {httpContext.Response.ContentType}\n" +
                    $"\tHeaders: {FormatHeaders(httpContext.Response.Headers)}\n" +
                    $"\tBody: {responseBodyText}");

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
