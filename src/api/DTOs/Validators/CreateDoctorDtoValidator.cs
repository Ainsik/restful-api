using api.DbContext;
using FluentValidation;

namespace api.DTOs.Validators
{
    public class CreateDoctorDtoValidator : AbstractValidator<CreateDoctorDto>
    {
        public CreateDoctorDtoValidator(RestDbContext dbContext)
        {
            RuleFor(d => d.FirstName)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Value can't be longer than 50 characters.");

            RuleFor(d => d.LastName)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Value can't be longer than 50 characters.");

            RuleFor(d => d.Phone)
                .NotEmpty()
                .Length(9)
                .WithMessage("The property must contain exactly 9 characters.");

            RuleFor(d => d.Specialization)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Value can't be longer than 50 characters.");
        }
    }
}
