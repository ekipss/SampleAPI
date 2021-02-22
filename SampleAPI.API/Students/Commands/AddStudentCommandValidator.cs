using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.API.Students.Commands
{
    public class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
    {
        public AddStudentCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty").MinimumLength(6);
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be empty").MinimumLength(6);

        }
    }
}
