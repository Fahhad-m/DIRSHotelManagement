using DIRSHotelManagement;
using DIRSHotelManagement.Interfaces;
using DIRSHotelManagement.Models;
using DIRSHotelManagement.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;


class Program
{

    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
       Host.CreateDefaultBuilder(args)
           .ConfigureWebHostDefaults(webBuilder =>
           {
               webBuilder.UseStartup<Startup>();
           });





}

















//var builder = WebApplication.CreateBuilder(args);



//// Add services to the container.
//builder.Services.AddControllers();
//builder.Services.Configure<MongoDbSettings>(
//    builder.Configuration.GetSection("MongoDbSettings"));
//builder.Services.AddSingleton<MongoDbContext>();
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IAvailabilityRepository, AvailabilityRepository>();





//builder.Services.AddControllers();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

////var serviceProvider = builder.Services.BuildServiceProvider();
////var startup = new Startup(builder.Configuration);

////startup.ConfigureServices(builder.Services);

//// Create an instance of Startup and use it to configure the application
//var startup = new Startup(builder.Configuration);
//startup.ConfigureServices(builder.Services);
//var serviceProvider = builder.Services.BuildServiceProvider();
////startup.ConfigureServices(app, serviceProvider);



//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}


////app.UseHttpsRedirection();

////app.UseAuthorization();

////app.MapControllers();

//app.Run();
