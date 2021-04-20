using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.DTO.DTOs.AppUSerDtos
{
    public class AppUserSignInDto
    {
        //[Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        //[Display(Name = "Kullanıcı Adı :")]
        public string UserName { get; set; }
        //[Required(ErrorMessage = "Parola alanı boş geçilemez")]
        //[Display(Name = "Parola :")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }

        //[Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
