using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PensionManagementSystem.Application.Dtos;

namespace PensionManagementSystem.Application.Validators
{
    public class ContributionDtoValidator : AbstractValidator<ContributionDto>
    {
        public ContributionDtoValidator()
        {
            RuleFor(x => x.ContributionType).IsInEnum();
            RuleFor(x => x.Amount).GreaterThan(0);
            RuleFor(x => x.ContributionDate).NotEmpty();
            RuleFor(x => x.ReferenceNumber).NotEmpty().Matches("^[A-Z0-9-]+$");
            RuleFor(x => x.MemberId).NotEmpty();
        }
    }
}
