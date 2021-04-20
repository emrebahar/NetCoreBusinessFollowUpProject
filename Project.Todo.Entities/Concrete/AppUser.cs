using Microsoft.AspNetCore.Identity;
using Project.Todo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.Entities.Concrete
{
    public class AppUser : IdentityUser<int> , ITablo
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Picture { get; set; } = "default.png";
        public List<Bildirim> Bildirimler { get; set; }
        public List<Gorev> Gorevler { get; set; }
    }
}
