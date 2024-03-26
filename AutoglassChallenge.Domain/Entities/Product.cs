using AutoglassChallenge.Domain.DTOs;
using AutoglassChallenge.Domain.Validators;
using FluentValidation.Results;

namespace AutoglassChallenge.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product() { 
        }

        public string Description { get; private set; }
        public bool Status { get; private set; }
        public DateTime ManufacturingDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public int SupplierCode { get; private set; }
        public string SupplierDescription { get; private set; }
        public string SupplierCNPJ { get; private set; }

        public Product(ProductDto dto)
        {
            Description = dto.Description;
            Status = true;
            ManufacturingDate = dto.ManufacturingDate;
            ExpirationDate = dto.ExpirationDate;
            SupplierCode = dto.SupplierCode;
            SupplierDescription = dto.SupplierDescription;
            SupplierCNPJ = dto.SupplierCNPJ;
            
        }

        public void Update(ProductDto productDto)
        {
            Description = productDto.Description;
            ManufacturingDate = productDto.ManufacturingDate;
            ExpirationDate = productDto.ExpirationDate;
            SupplierCode = productDto.SupplierCode;
            SupplierCNPJ = productDto.SupplierCNPJ;
            SupplierDescription = productDto.SupplierDescription;
        }

        public void Disable()
        {
            this.Status = false;
        }

        public void Enable()
        {
            this.Status = true;
        }


        public ValidationResult IsValid() => new ProductValidator().Validate(this);
    }
}
