using System.Text.RegularExpressions;
using application.Dto;
using FluentValidation;
using infrastructure.DbContext;

namespace infrastructure.Configuration.Dto;

public class BaseDoctorDtoValidator : AbstractValidator<BaseDoctorDto>
{
    public BaseDoctorDtoValidator(RestDbContext dbContext)
    {
        RuleFor(d => d.FullName)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("Value can't be longer than 100 characters.");

        RuleFor(d => d.Phone)
            .NotEmpty()
            .Length(9)
            .WithMessage("The property must contain exactly 9 characters.");

        RuleFor(d => d.Specialization)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage("Value can't be longer than 50 characters.");

        RuleFor(d => d.City)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage("Value can't be longer than 50 characters.");

        RuleFor(d => d.Street)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage("Value can't be longer than 50 characters.");

        RuleFor(x => x.PostalCode)
            .Matches(new Regex("\\d{2}-\\d{3}"))
            .WithMessage("Invalid postal code format.");
    }
}