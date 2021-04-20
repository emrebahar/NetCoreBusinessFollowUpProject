using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.Todo.Web;
using Project.Todo.Business.Concrete;
using Project.Todo.Business.Interfaces;
using Project.Todo.DataAccess.Concrete.EntityFrameworkCore.Context;
using Project.Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Project.Todo.DataAccess.Interfaces;
using Project.Todo.Entities.Concrete;
using System;
using FluentValidation.AspNetCore;
using AutoMapper;
using FluentValidation;
using Project.Todo.DTO.DTOs.AciliyetDtos;
using Project.Todo.Business.ValidationRules.FluentValidation;
using Project.Todo.DTO.DTOs.AppUSerDtos;
using Project.Todo.DTO.DTOs.GorevDtos;
using Project.Todo.DTO.DTOs.RaporDtos;
using Project.Todo.Business.DiContainer;
using Project.Todo.Web.CustomCollectionExtensions;

namespace Project.ToDo.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddContainerWithDependencies();

            services.AddDbContext<TodoContext>();

            services.AddCustomIdentity();

            services.AddAutoMapper(typeof(Startup));

            services.AddCustomValidator();

            services.AddControllersWithViews().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStatusCodePagesWithReExecute("/Home/StatusCode", "?code={0}");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            IdentityInitializer.SeedData(userManager, roleManager).Wait();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
