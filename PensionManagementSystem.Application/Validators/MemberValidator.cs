using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PensionManagementSystem.Application.Dtos;

namespace PensionManagementSystem.Application.Validators
{
    public class MemberDtoValidator : AbstractValidator<MemberDto>
    {
        public MemberDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth)
                .Must(d => d <= DateTime.UtcNow.AddYears(-18) && d >= DateTime.UtcNow.AddYears(-70))
                .WithMessage("Member age must be between 18 and 70 years.");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Phone number must be in E.164 format.");

            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.EmployerId).NotEmpty();
        }
    }
}
