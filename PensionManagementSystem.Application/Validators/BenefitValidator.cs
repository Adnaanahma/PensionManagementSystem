using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PensionManagementSystem.Application.Dtos;

namespace PensionManagementSystem.Application.Validators
{
    public class BenefitDtoValidator : AbstractValidator<BenefitDto>
    {
        public BenefitDtoValidator()
        {
            RuleFor(x => x.BenefitType)
                .IsInEnum()
                .WithMessage("Invalid benefit type.");

            RuleFor(x => x.CalculationDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Calculation date cannot be in the future.");

            RuleFor(x => x.EligibilityStatus)
                .NotNull();

            RuleFor(x => x.Amount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Amount must be a positive number.");

            RuleFor(x => x.MemberId)
                .NotEmpty()
                .WithMessage("Member ID is required.");
        }
    }
}
