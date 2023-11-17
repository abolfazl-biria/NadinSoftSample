using Application.Models.Commands.Products;
using Common.Configurations;
using FluentValidation;

namespace Application.Validators.Products;

public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
{
    public AddProductCommandValidator()
    {
        RuleFor(x => x.ProduceDate)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.ManufactureEmail)
            .EmailAddress()
            .MaximumLength(FieldConfig.EmailLength)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.ManufacturePhone)
            .MaximumLength(FieldConfig.PhoneLength)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Name)
            .MaximumLength(FieldConfig.NameLength)
            .NotNull()
            .NotEmpty();
    }
}