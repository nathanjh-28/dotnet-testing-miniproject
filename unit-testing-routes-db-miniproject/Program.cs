using unit_testing_routes_db_miniproject.Data;
using unit_testing_routes_db_miniproject.Services;

namespace unit_testing_routes_db_miniproject;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSqlite<ProjectContext>("Data Source=Projects.db");

        builder.Services.AddScoped<ProjectService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.CreateDbIfNotExists();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();


        app.Run();
    }
}
