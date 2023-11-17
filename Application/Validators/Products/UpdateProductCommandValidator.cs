using Application.Models.Commands.Products;
using Common.Configurations;
using FluentValidation;

namespace Application.Validators.Products;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .GreaterThan(0)
            .NotEmpty();

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