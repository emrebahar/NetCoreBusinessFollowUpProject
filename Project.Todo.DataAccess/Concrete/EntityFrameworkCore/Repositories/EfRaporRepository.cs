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
    public class EfRaporRepository : EfGenericRepository<Rapor>, IRaporDal
    {
        public Rapor GetirGorevileId(int id)
        {
            using var context = new TodoContext();
            return context.Raporlar.Include(I => I.Gorev).ThenInclude(I => I.Aciliyet).Where(I => I.Id == id).FirstOrDefault();
        }

        public int GetirRaporSayisi()
        {
            using var context = new TodoContext();
            return context.Raporlar.Count();
        }

        public int GetirRaporSayisiileAppUserId(int id)
        {
            using var context = new TodoContext();
            var result = context.Gorevler.Include(I => I.Raporlar).Where(I => I.AppUserId == id);

            return result.SelectMany(I => I.Raporlar).Count();

        }
    }
}
