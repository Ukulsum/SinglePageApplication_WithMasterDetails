using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinglePageApplication.Models
{
    public class SaleMasters
    {
        [Key]
        public int SaleId { get; set; }
        public DateTime? CreateDate { get; set; }
        [Required]
        public string? CustomerName { get; set; }
        public string? Gender { get; set; }
        public string? Photo { get; set; }
        public string? CustomerAddress { get; set; }

        [NotMapped]
        public IFormFile ImagePath { get; set; }
    }
}
