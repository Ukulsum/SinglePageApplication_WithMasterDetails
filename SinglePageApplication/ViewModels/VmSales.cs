using System.ComponentModel.DataAnnotations;

namespace SinglePageApplication.ViewModels
{
    public class VmSales
    {
        [Key]
        public int SaleId { get; set; }
        public DateTime? CreateDate { get; set; }
        [Required]
        public string? CustomerName { get; set; }
        public string? Gender { get; set; }
        public string? Photo { get; set; }
        public string? CustomerAddress { get; set; }

        public IFormFile ImagePath { get; set; }


        public List<VmSaleDetails> SaleDetails { get; set; } = new List<VmSaleDetails>();
        public string?[] ProductName { get; set; }
        public string?[] ProductType { get; set; }
        public decimal?[] Quentity { get; set; }
        public decimal?[] Price { get; set; }

        public class VmSaleDetails
        {
            [Key]
            public int SaleDetailId { get; set; }
            public int? SaleId { get; set; }
            public string? ProductName { get; set; }
            public string? ProductType { get; set; }
            public decimal? Quentity { get; set; }
            public decimal? Price { get; set; }
        }
    }
}
