using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PensionManagementSystem.Application.Dtos;

namespace PensionManagementSystem.Application.Validators
{
    public class EmployerDtoValidator : AbstractValidator<EmployerDto>
    {
        public EmployerDtoValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().MaximumLength(200);
            RuleFor(x => x.RegistrationNumber).NotEmpty().Matches("^[A-Z0-9]{6,15}$");
            RuleFor(x => x.IsActive).NotNull().WithMessage("IsActive status must be specified.");

        }
    }

}
