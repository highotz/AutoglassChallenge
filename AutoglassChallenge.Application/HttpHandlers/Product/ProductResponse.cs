﻿namespace AutoglassChallenge.Application.HttpHandlers.Product
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int SupplierCode { get; set; }
        public string SupplierDescription { get; set; }
        public string SupplierCnpj { get; set; }

    }
}
