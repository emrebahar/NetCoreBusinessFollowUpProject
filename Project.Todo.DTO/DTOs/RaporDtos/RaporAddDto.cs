using Project.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.DTO.DTOs.RaporDtos
{
    public class RaporAddDto
    {
        //[Display(Name = "Tanım :")]
        //[Required(ErrorMessage = "Tanım alanı boş geçilemez")]
        public string Tanim { get; set; }
        //[Display(Name = "Detay :")]
        //[Required(ErrorMessage = "Detay alanı boş geçilemez")]
        public string Detay { get; set; }
        public Gorev Gorev { get; set; }
        public int GorevId { get; set; }
    }
}
