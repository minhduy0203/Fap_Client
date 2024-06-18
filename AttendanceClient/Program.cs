using AttendanceClient.Service;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AttendanceClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            builder.Services.AddTransient<UserService>();
            builder.Services.AddTransient<ScheduleService>();
            builder.Services.AddTransient<AttendanceService>();
			builder.Services.AddTransient<StudentCourseService>();


			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapRazorPages();

            app.Run();
        }
    }
}