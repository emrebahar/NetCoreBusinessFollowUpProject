using Project.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.Business.Interfaces
{
    public interface IBildirimService : IGecericService<Bildirim>
    {
        List<Bildirim> GetirOkunmayanlar(int AppUserId);
        int GetirOkunmayanSayisiileAppUserId(int AppUserId);
    }
}
