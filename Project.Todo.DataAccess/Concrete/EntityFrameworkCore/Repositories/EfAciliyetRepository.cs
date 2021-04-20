using Project.Todo.DataAccess.Interfaces;
using Project.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAciliyetRepository : EfGenericRepository<Aciliyet>, IAciliyetDal
    {
    }
}
