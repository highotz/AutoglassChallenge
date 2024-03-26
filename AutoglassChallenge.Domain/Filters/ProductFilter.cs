namespace AutoglassChallenge.Domain.Filters
{
    public class ProductFilter
    {
        public string? Description { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? Status { get; set; }
        public string? SupplierCode { get; set; }
        public string? SupplierDescription { get; set; }
        public string? SupplierCNPJ { get; set; }
        public int ItemsByPage { get; set; } = 1;
        public int PageIndex { get; set; } = 1;
    }
}
