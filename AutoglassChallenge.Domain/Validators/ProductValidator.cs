using AutoglassChallenge.Domain.Entities;
using FluentValidation;

namespace AutoglassChallenge.Domain.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.ManufacturingDate)
                .LessThan(product => product.ExpirationDate)
                .WithMessage("A data de validade deve ser maior que a data de fabricação.");

            RuleFor(x => x.Description)
                .NotNull()
                .WithMessage("A descrição do produto é obrigatória.");
        }
    }
}
