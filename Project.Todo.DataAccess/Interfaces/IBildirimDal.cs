using Project.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.DataAccess.Interfaces
{
    public interface IBildirimDal : IGenericDal<Bildirim>
    {
        List<Bildirim> GetirOkunmayanlar(int AppUserId);
        int GetirOkunmayanSayisiileAppUserId(int AppUserId);
    }
}
