
using Hyper_Radio_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Radio_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //This is a dynamic switch to change the connection string depending on lacal variable
            var activeConnectionName = builder.Configuration["ConnectionStrings:ActiveConnection"] 
                                       ?? "DefaultConnection";

            var connectionString = builder.Configuration.GetConnectionString(activeConnectionName);

            // Add services to the container.
            builder.Services.AddDbContext<HyperRadioDbContext>(options =>
                options.UseSqlServer(connectionString))
                ;

            builder.Services.AddControllers();
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
