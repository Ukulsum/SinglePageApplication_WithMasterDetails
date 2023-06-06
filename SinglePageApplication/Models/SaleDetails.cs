using System.ComponentModel.DataAnnotations;

namespace SinglePageApplication.Models
{
    public class SaleDetails
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
