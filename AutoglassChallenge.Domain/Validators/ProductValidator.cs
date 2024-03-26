using AutoglassChallenge.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
