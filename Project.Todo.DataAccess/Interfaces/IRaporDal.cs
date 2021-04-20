using Project.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.DataAccess.Interfaces
{
    public interface IRaporDal : IGenericDal<Rapor>
    {
        Rapor GetirGorevileId(int id);
        int GetirRaporSayisiileAppUserId(int id);
        int GetirRaporSayisi();
    }
}
