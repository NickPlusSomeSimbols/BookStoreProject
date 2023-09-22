using Microsoft.EntityFrameworkCore;
using BookStoreProjectCore;
using BookStoreProjectInfrastructure.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<BookStoreDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddScoped<BookDataService>();
builder.Services.AddScoped<AuthorDataService>();
builder.Services.AddScoped<BookStorageDataService>();
builder.Services.AddScoped<BookStoreDataService>();
builder.Services.AddScoped<BasketDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
