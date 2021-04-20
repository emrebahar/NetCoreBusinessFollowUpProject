using Project.Todo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.Entities.Concrete
{
    public class Aciliyet : ITablo
    {
        public int Id { get; set; }
        public string Tanim { get; set; }

        public List<Gorev> Gorevler { get; set; }
    }
}
