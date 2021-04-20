using FluentValidation;
using Project.Todo.DTO.DTOs.AppUSerDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.Business.ValidationRules.FluentValidation
{
    public class AppUserSignInValidator : AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Kullanıcı Adı boş geçilemez.");
            RuleFor(I => I.Password).NotNull().WithMessage("Parola alanı boş geçilemez.");
        }
    }
}
