using FluentValidation;
using Project.Todo.DTO.DTOs.GorevDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.Business.ValidationRules.FluentValidation
{
    public class GorevAddValidator : AbstractValidator<GorevAddDto>
    {
        public GorevAddValidator()
        {
            RuleFor(I => I.Ad).NotNull().WithMessage("Ad alanı boş geçilemez.");
            //RuleFor(I => I.Aciklama).NotNull().WithMessage("Açıklama alanı boş geçilemez.");
            RuleFor(I => I.AciliyetId).ExclusiveBetween(0, int.MaxValue).WithMessage("Lütfen bir aciliyet durumu seçiniz.");
        }
    }
}
