using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoglassChallenge.Domain.Entities
{
    internal class Product
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; } = true;
        public DateTime manufacturingDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int SupplierCode { get; set; }
        public string? SupplierDescription { get; set; }
        public string? SupplierCNPJ { get; set; }
    }
}
