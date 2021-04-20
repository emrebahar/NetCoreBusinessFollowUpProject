using FluentValidation;
using Project.Todo.DTO.DTOs.GorevDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.Business.ValidationRules.FluentValidation
{
    public class GorevUpdateValidator : AbstractValidator<GorevUpdateDto>
    {
        public GorevUpdateValidator()
        {
            RuleFor(I => I.Ad).NotNull().WithMessage("Ad alanı Bboş geçilemez.");
            RuleFor(I => I.AciliyetId).ExclusiveBetween(0, int.MaxValue).WithMessage("Lütfen bir aciliyet durumu seçiniz.");
        }
    }
}
