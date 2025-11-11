using Microsoft.AspNetCore.Builder;
using RestaurantMenu.API.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using RestaurantMenu.API.Models;
using RestaurantMenu.API.Repositories;
using RestaurantMenu.API.Services;

var builder = WebApplication.CreateBuilder(args);

//Add services (DI Container)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MongoDB Connection
var mongoSettings = builder.Configuration.GetSection("MongoDB");
var connectionString = mongoSettings.GetValue<string>("ConnectionString");
var databaseName = mongoSettings.GetValue<string>("DatabaseName");

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(connectionString));
builder.Services.AddScoped<IMongoDatabase>(s => 
    s.GetRequiredService<IMongoClient>().GetDatabase(databaseName));
builder.Services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));
builder.Services.AddScoped<MenuService>();


builder.Services.AddScoped<IRepository<MenuItem>>(sp =>
{
    var database = sp.GetRequiredService<IMongoDatabase>();
    return new MongoRepository<MenuItem>(database, "MenuItems");
});

var app = builder.Build();

//Middleware pipeline
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

