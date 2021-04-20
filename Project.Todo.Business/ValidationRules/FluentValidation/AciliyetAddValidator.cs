using FluentValidation;
using Project.Todo.DTO.DTOs.AciliyetDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.Business.ValidationRules.FluentValidation
{
    public class AciliyetAddValidator : AbstractValidator<AciliyetAddDto>
    {
        public AciliyetAddValidator()
        {
            RuleFor(I => I.Tanim).NotNull().WithMessage("Tanım alanı boş geçilemez.");
        }
    }
}
