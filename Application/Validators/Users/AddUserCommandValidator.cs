using Application.Models.Commands.Users;
using Common.Configurations;
using FluentValidation;

namespace Application.Validators.Users;

public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
{
    public AddUserCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Email)
            .EmailAddress()
            .MaximumLength(FieldConfig.EmailLength)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.PhoneNumber)
            .MaximumLength(FieldConfig.PhoneLength)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty();
    }
}