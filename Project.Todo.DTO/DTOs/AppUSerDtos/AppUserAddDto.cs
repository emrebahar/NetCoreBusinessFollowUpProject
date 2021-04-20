using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.DTO.DTOs.AppUSerDtos
{
    public class AppUserAddDto
    {
        //[Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        //[Display(Name = "Kullanıcı Adı :")]
        public string UserName { get; set; }
        //[Required(ErrorMessage = "Parola alanı boş geçilemez")]
        //[Display(Name = "Parola :")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
        //[Compare("Password", ErrorMessage = "Parolalar eşleşmiyor")]
        //[Display(Name = "Parolanızı Tekrar Giriniz :")]
        //[DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        //[Required(ErrorMessage = "Email alanı boş geçilemez")]
        //[Display(Name = "Email :")]
        //[EmailAddress(ErrorMessage = "Geçersiz Email")]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Ad alanı boş geçilemez")]
        //[Display(Name = "Adınız :")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        //[Display(Name = "Soyadınız :")]
        public string SurName { get; set; }
    }
}
