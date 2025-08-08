using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PensionManagementSystem.Application.Dtos;
using PensionManagementSystem.Application.Enums;

namespace PensionManagementSystem.Application.Validators
{
    public class ContributionDtoValidator : AbstractValidator<ContributionDto>
    {
        public ContributionDtoValidator()
        {
            RuleFor(x => x.ContributionType)
            .IsInEnum()
            .WithMessage("Invalid contribution type.");

            RuleFor(x => x.Amount)
                .GreaterThan(0)
                .WithMessage("Contribution amount must be greater than zero.");

            RuleFor(x => x.ContributionDate)
            .NotEmpty()
            .WithMessage("Contribution date is required.")
            .Must((dto, date) => IsValidDate(dto.ContributionType, date))
            .WithMessage("Invalid contribution date for the selected contribution type.");

            RuleFor(x => x.ReferenceNumber).NotEmpty().Matches("^[A-Z0-9-]+$");

            RuleFor(x => x.MemberId).NotEmpty().WithMessage("Member ID is required.");

        }

        private bool IsValidDate(ContributionType type, DateTime date)
        {
            if (type == ContributionType.Voluntary)
                return true; // unrestricted

            if (type == ContributionType.Monthly)
            {
                var now = DateTime.UtcNow;
                return date.Year == now.Year && date.Month == now.Month;
            }

            return false;
        }
    }
}
