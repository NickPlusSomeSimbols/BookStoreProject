using Microsoft.EntityFrameworkCore;
using BookStoreProjectCore;
using BookStoreProjectInfrastructure.Data.Services;
using BookStoreProjectInfrastructure.Providers;
using Microsoft.AspNetCore.Identity;
using BookStoreProjectCore.IdentityAuth;
using BookStoreProjectAPI.Extentions;
using BookStoreProjectInfrastructure.Data.SeviceInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<BookStoreDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();
builder.Services.AddScoped<IBookDataService, BookDataService>();
builder.Services.AddScoped<IAuthorDataService, AuthorDataService>();
builder.Services.AddScoped<IBookStorageDataService, BookStorageDataService>();
builder.Services.AddScoped<IBookStoreDataService, BookStoreDataService>();
builder.Services.AddScoped<IBasketDataService, BasketDataService>();
builder.Services.AddScoped<ILoggerDataService, LoggerDataService>();

builder.Services.AddScoped<IInnlineClientService, InnlineClientService>();
builder.Services.AddScoped<IInnlineLocationService, InnlineLocationService>();

builder.Services.AddScoped<UserProvider>();

builder.Services.AddHttpClient("BookStoreToInnline", client =>
{
    client.BaseAddress = new Uri("https://trackermakerapidev.innline.am/");
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<BookStoreDbContext>()
    .AddDefaultTokenProviders();

builder.AddAuthentication();

builder.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication(); // identifying who the user is
app.UseAuthorization(); // defines what a given user can do within the app

app.MapControllers();

app.UseMiddleware<LoggingMiddleware>();

app.Run();
