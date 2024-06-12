using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using DIRSHotelManagement.Service;
using DIRSHotelManagement.Interfaces;
using DIRSHotelManagement.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;

using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;

namespace DIRSHotelManagement
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.Configure<MongoDbSettings>(Configuration.GetSection("MongoDbSettings"));
            services.AddSingleton<MongoDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IAvailabilityRepository, AvailabilityRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DIRS21", Version = "v1" });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DIRS v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
