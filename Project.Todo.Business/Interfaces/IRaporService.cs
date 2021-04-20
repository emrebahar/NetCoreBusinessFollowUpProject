using Project.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.Business.Interfaces
{
    public interface IRaporService : IGecericService<Rapor>
    {
        Rapor GetirGorevileId(int id);
        int GetirRaporSayisiileAppUserId(int id);
        int GetirRaporSayisi();
    }
}
