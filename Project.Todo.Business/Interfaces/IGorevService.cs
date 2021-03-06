using Project.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Project.Todo.Business.Interfaces
{
    public interface IGorevService : IGecericService<Gorev>
    {
        List<Gorev> GetirAciliyetIleTamamlanmayan();
        List<Gorev> GetirTumTablolarla();
        Gorev GetirAciliyetileId(int id);
        List<Gorev> GetirileAppUserId(int appUserId);
        Gorev GetirRaporlarileId(int id);
        List<Gorev> GetirTumTablolarla(Expression<Func<Gorev, bool>> filter);
        List<Gorev> GetirTumTablolarlaTamamlanmayan(out int toplamSayfa, int userId, int aktifSayfa = 1);
        int GetirGorevSayisiTamamlananileAppUserId(int id);
        int GetirGorevSayisiTamamlanmasiGerekenileAppUserId(int id);
        int GetirGorevSayisiAtanmayiBekleyen();
        int GetirGorevTamamlanmis();
    }
}
