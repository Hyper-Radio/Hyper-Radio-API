
using System.Text;
using Hyper_Radio_API.Data;
using Hyper_Radio_API.Repositories;
using Hyper_Radio_API.Repositories.TrackRepositories;
using Hyper_Radio_API.Services.ShowServices;
using Hyper_Radio_API.Services.TokenServices;
using Hyper_Radio_API.Services.TrackServices;
using Hyper_Radio_API.Services.UploadServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            builder.Services.AddScoped<ITokenService, TokenService>();


            builder.Services.Configure<AzureBlobSettings>(
                builder.Configuration.GetSection("AzureBlob"));
            builder.Services.AddSingleton<AzureBlobService>();
            builder.Services.AddSingleton<HlsConverterService>();
            
            
            // Add CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSwaggerUI", policy =>
                {
                    policy.AllowAnyOrigin()    // or specify origins
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
            });
            builder.Services.AddAuthorization();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            
            app.Run();
        }
    }
}
