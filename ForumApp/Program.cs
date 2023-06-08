
using Forum.Services;
using Forum.Services.Interfaces;
using ForumApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ForumApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
			string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			// Allows us to take instance of dbContext throughout the entire application
			builder.Services.AddDbContext<ForumDBContext>(options =>
			{
				options.UseSqlServer(connectionString);
			});

			// Add custom services
			builder.Services.AddScoped<IPostService, PostService>();

			WebApplication app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				//app.UseExceptionHandler("/Home/Error");
				app.UseDeveloperExceptionPage(); // better option

				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
