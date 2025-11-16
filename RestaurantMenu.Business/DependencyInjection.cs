using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using RestaurantMenu.Data.Repositories;
using RestaurantMenu.Data.Entities;
using RestaurantMenu.Business.Services;

namespace RestaurantMenu.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            // MongoDB Connection
            var mongoSettings = configuration.GetSection("MongoDB");
            var connectionString = mongoSettings.GetValue<string>("ConnectionString");
            var databaseName = mongoSettings.GetValue<string>("DatabaseName");

            services.AddScoped<IRepository<MenuItem>>(sp =>
            {
                var database = sp.GetRequiredService<IMongoDatabase>();
                return new MongoRepository<MenuItem>(database, "MenuItems");
            });


            services.AddSingleton<IMongoClient>(s=> new MongoClient(connectionString));
            services.AddScoped<IMongoDatabase>(s=>s.GetRequiredService<IMongoClient>().GetDatabase(databaseName));

            //Register generic repositories
            services.AddScoped(typeof(IRepository<>),typeof(MongoRepository<>));

            //Register menu specific services
            services.AddScoped<MenuService>();

            return services;
        }
    }
}


