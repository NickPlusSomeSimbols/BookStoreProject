using Microsoft.EntityFrameworkCore;
using BookStoreProjectCore;
using BookStoreProjectInfrastructure.Data.Services;
using BookStoreProjectInfrastructure.Providers;
using Microsoft.AspNetCore.Identity;
using BookStoreProjectCore.IdentityAuth;
using BookStoreProjectAPI.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<BookStoreDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddScoped<AuthenticateService>();
builder.Services.AddScoped<BookDataService>();
builder.Services.AddScoped<AuthorDataService>();
builder.Services.AddScoped<BookStorageDataService>();
builder.Services.AddScoped<BookStoreDataService>();
builder.Services.AddScoped<BasketDataService>();
builder.Services.AddScoped<LoggerDataService>();
builder.Services.AddScoped<UserProvider>();

/*builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.LoggingFields = HttpLoggingFields.ResponseStatusCode;
    logging.ResponseHeaders.Add("MyResponseHeader");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;

});*/

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<BookStoreDbContext>()
    .AddDefaultTokenProviders();

builder.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication(); // identifying who the user is
app.UseAuthorization(); // defines what a given user can do within the app

app.MapControllers();

/*app.UseRouting();*/

app.UseMiddleware<LoggingMiddleware>();

app.Run();
