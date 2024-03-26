namespace AutoglassChallenge.Application.HttpHandlers.Product
{
    public class ProductRequest
    {
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int SupplierCode { get; set; }
        public int SupplierDescription { get; set; }
        public int SupplierCNPJ { get; set; }
    }
}
