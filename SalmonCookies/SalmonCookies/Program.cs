using Microsoft.EntityFrameworkCore;
using SalmonCookies.Data;
using SalmonCookies.Interfaces;
using SalmonCookies.Services;

namespace SalmonCookies
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();

			string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

			builder.Services.AddDbContext<SalmonCookieDbContext>
				(options => options.UseSqlServer(connectionString));

			builder.Services.AddScoped<ICookieStands, CookieStandsService>();

			builder.Services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo()
				{
					Title = "Cookie Salmon API",
					Version = "V1"
				});
			});


			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAnyOriginPolicy", builder =>
				{
					builder
					.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader();

				});
			}
		 );
			var app = builder.Build();

			app.UseSwagger(options =>
			{
				options.RouteTemplate = "/api/{documentName}/swagger.json";
			});

			app.UseSwaggerUI(options =>
			{
				// put the End point 
				options.SwaggerEndpoint ("/api/V1/swagger.json", "Cookie API");
				options.RoutePrefix = ("docs");
			});

			app.UseCors("AllowAnyOriginPolicy");


			app.MapGet("/", context =>
			{
				context.Response.Redirect("/docs");
				return Task.CompletedTask;
			});


			app.MapControllers();

			app.Run();
		}
	}
}