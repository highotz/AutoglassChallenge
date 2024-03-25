using AutoglassChallenge.Domain.Entities;

namespace AutoglassChallenge.Application.DTOs
{
    public class ProductRequest
    {
        public string Description { get; init; }
        public bool Status { get; init; }
        public DateTime ManufacturingDate { get; init; }
        public DateTime ExpirationDate { get; init; }
        public int SupplierCode { get; init; }
        public string SupplierDescription { get; init; }
        public string SupplierCNPJ { get; init; }
    }
}
