using emp_system.Models;
using emp_system.repositiry;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace emp_system
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<appcontext>(option =>
            {
                  option.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            builder.Services.AddIdentity<appuser,IdentityRole>().AddEntityFrameworkStores<appcontext>();



            builder.Services.AddScoped<Ipatientrepo, patientrepo>();
            builder.Services.AddScoped<Iappointmentrepo, appointmentrepo>();
            builder.Services.AddScoped<Idoctorrepo,doctorrepo >();
            builder.Services.AddScoped<Ispecialtyrepo,specialtyrepo >();
           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
