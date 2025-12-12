
using EtteremApi.Models;
using EtteremApi.Models.Dtos;
using EtteremApi.Services;
using EtteremApi.Services.Etterem;

namespace EtteremApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<EtteremContext>();
            builder.Services.AddScoped<IRendeles, RendelesService>();
            builder.Services.AddScoped<ResponseDto>();
            builder.Services.AddScoped<ITermek, TermekService>();
            builder.Services.AddScoped<IRendelesTetel, RendelesTetelService>();

            // Add services to the container.

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
