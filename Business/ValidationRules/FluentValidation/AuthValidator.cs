using Core.DTOs;
using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AuthValidator : AbstractValidator<RegisterDto>
    {
        public AuthValidator()
        {
            RuleFor(rto=>rto.Email).NotEmpty();
            RuleFor(rto=>rto.Password).NotEmpty();
            RuleFor(rto=>rto.UserName).NotEmpty();
            RuleFor(rto => rto.LastName).NotEmpty();
            RuleFor(rto => rto.Email).EmailAddress();
            RuleFor(rto=>rto.Password).MinimumLength(6);
            RuleFor(rto=>rto.UserName).Must(StartWithA).WithMessage("A ile başlamamalı.");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }

    }
}
