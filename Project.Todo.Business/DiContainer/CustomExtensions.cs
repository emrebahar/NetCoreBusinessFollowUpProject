using Microsoft.Extensions.DependencyInjection;
using Project.Todo.Business.Concrete;
using Project.Todo.Business.Interfaces;
using Project.Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Project.Todo.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.Business.DiContainer
{
    public static class CustomExtensions
    {
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            services.AddScoped<IGorevService, GorevManager>();
            services.AddScoped<IAciliyetService, AciliyetManager>();
            services.AddScoped<IRaporService, RaporManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IDosyaService, DosyaManager>();
            services.AddScoped<IBildirimService, BildirimManager>();

            services.AddScoped<IGorevDal, EfGorevRepository>();
            services.AddScoped<IAciliyetDal, EfAciliyetRepository>();
            services.AddScoped<IRaporDal, EfRaporRepository>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IBildirimDal, EfBildirimRepository>();
        }
    }
}
