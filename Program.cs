
using Hyper_Radio_API.Data;
using Hyper_Radio_API.Repositories;
using Hyper_Radio_API.Repositories.TrackRepositories;
using Hyper_Radio_API.Services.ShowServices;
using Hyper_Radio_API.Services.TrackServices;
using Hyper_Radio_API.Services.UploadServices;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Radio_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //This is a dynamic switch to change the connection string depending on lacal variable
            var activeConnectionName = builder.Configuration["ConnectionStrings:ActiveConnection"];

            var connectionString = builder.Configuration.GetConnectionString(activeConnectionName);

            // Add services to the container.
            builder.Services.AddDbContext<HyperRadioDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ITrackService, TrackService>();
            builder.Services.AddScoped<ITrackRepository, TrackRepository>();
            builder.Services.AddScoped<IShowService, ShowService>();
            builder.Services.AddScoped<IShowRepository, ShowRepository>();

            
            builder.Services.Configure<AzureBlobSettings>(
                builder.Configuration.GetSection("AzureBlob"));
            builder.Services.AddSingleton<AzureBlobService>();
            builder.Services.AddSingleton<HlsConverterService>();
            
            
            // Add CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins("http://localhost:5122") // your MVC port
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            
            app.UseCors("AllowFrontend");


            app.UseAuthorization();


            app.MapControllers();

            /*
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<HyperRadioDbContext>();
                SeedData.InitializeDB(context);
            }
            
            */
            
            app.Run();
        }
    }
}
