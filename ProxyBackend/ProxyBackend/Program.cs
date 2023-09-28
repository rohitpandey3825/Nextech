using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using ProxyBackend.Common.Interfaces;
using ProxyBackend.Services;
using ProxyBackend.Services.Clients;
using ProxyBackend.Services.Redis;

namespace ProxyBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<INewsService, NewsService>();
            builder.Services.AddScoped<IRedisRepository, RedisRepository>();
            builder.Services.AddScoped<IHackerNewsClient, HackerNewsClient>();

            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:RedisCache");
            });
            builder.Services.Add(ServiceDescriptor.Singleton<IDistributedCache, RedisCache>());


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}