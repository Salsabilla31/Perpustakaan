using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PerpustakaanAPP.Api.Areas.AreaBook.Services;
using PerpustakaanAPP.Api.Areas.Rack.Services;
using PerpustakaanAPP.Api.Common.Extentions;
using PerpustakaanAPP.Api.Helpers;
using PerpustakaanAPP.Data.Access.Models;

namespace PerpustakaanAPP.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigurationHelper.Initialize(builder.Configuration);

            // Add conection string
            builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Registrasi service custom
            builder.Services.AddScoped<AreaBookService>();
            builder.Services.AddScoped<RackService>();
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Perpustakaan Api",
                    Version = "v1"
                });
            });


            builder.Services.AddAppServices(builder.Configuration);

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
