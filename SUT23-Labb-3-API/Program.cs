
using Microsoft.EntityFrameworkCore;
using PersonInterestAPI.Data;
using PersonInterestAPI.Repositories;
using SUT23_Labb_3_API.Services.Interface;
using SUT23_Labb_3_API.Services.Repos;

namespace SUT23_Labb_3_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
                    });

            builder.Services.AddScoped<IPerson, PersonRepo>();
            builder.Services.AddScoped<ILink, LinkRepo>();
            builder.Services.AddScoped<IInterest, InterestRepo>();

            builder.Services.AddDbContext<PersonDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
            });
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
