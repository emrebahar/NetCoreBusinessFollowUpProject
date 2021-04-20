using Microsoft.EntityFrameworkCore;
using Project.Todo.DataAccess.Concrete.EntityFrameworkCore.Context;
using Project.Todo.DataAccess.Interfaces;
using Project.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : IAppUserDal
    {
        public List<AppUser> GetirAdminOlmayanlar()
        {
            /*
             select * from UdemyTodo.dbo.AspNetUsers inner join UdemyTodo.dbo.AspNetUserRoles
on UdemyTodo.dbo.AspNetUsers.Id = AspNetUserRoles.UserId 
inner join UdemyTodo.dbo.AspNetRoles
on AspNetRoles.Id = AspNetUserRoles.RoleId where AspNetRoles.Name = 'Member'
             */
            using var context = new TodoContext();

            return context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole
            }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
            {
                user = resultTable.user,
                userRole = resultTable.userRole,
                roles = resultRole
            }).Where(I => I.roles.Name == "Member").Select(I => new AppUser
            {
                Id = I.user.Id,
                Name = I.user.Name,
                SurName = I.user.SurName,
                Email = I.user.Email,
                UserName = I.user.UserName,
                Picture = I.user.Picture
            }).ToList();


        }


        public List<AppUser> GetirAdminOlmayanlar(out int toplamSayfa, string aranacakKelime, int aktifSayfa = 1)
        {
            using var context = new TodoContext();

            var result = context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole
            }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
            {
                user = resultTable.user,
                userRole = resultTable.userRole,
                roles = resultRole
            }).Where(I => I.roles.Name == "Member").Select(I => new AppUser
            {
                Id = I.user.Id,
                Name = I.user.Name,
                SurName = I.user.SurName,
                Email = I.user.Email,
                UserName = I.user.UserName,
                Picture = I.user.Picture
            });

            toplamSayfa = (int)Math.Ceiling((double)result.Count() / 3);

            if (!string.IsNullOrWhiteSpace(aranacakKelime))
            {
                result = result.Where(I => I.Name.ToLower().Contains(aranacakKelime.ToLower()) || I.SurName.ToLower().Contains(aranacakKelime.ToLower()));
                toplamSayfa = (int)Math.Ceiling((double)result.Count() / 3);
            }

            result = result.Skip((aktifSayfa - 1) * 3).Take(3);

            return result.ToList();
        }
        public List<DualHelper> GetirEnCokGorevTamamlamisPersoneller()
        {
            using var context = new TodoContext();
            return context.Gorevler.Include(I => I.AppUser).Where(I => I.Durum).GroupBy(I => I.AppUser.Name).OrderByDescending(I => I.Count()).Take(5).Select(I=> new DualHelper{ 
                Isim = I.Key,
                GorevSayisi = I.Count()
            }).ToList();

        }
        public List<DualHelper> GetirEnCokGorevdeCalisanPersoneller()
        {
            using var context = new TodoContext();
            return context.Gorevler.Include(I => I.AppUser).Where(I => !I.Durum && I.AppUserId!=null).GroupBy(I => I.AppUser.Name).OrderByDescending(I => I.Count()).Take(5).Select(I => new DualHelper
            {
                Isim = I.Key,
                GorevSayisi = I.Count()
            }).ToList();

        }
    }
}
