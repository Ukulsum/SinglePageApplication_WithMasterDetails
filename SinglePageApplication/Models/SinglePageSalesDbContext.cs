using Microsoft.EntityFrameworkCore;

namespace SinglePageApplication.Models
{
    public class SinglePageSalesDbContext : DbContext
    {
        public SinglePageSalesDbContext() 
        { 
        }

        public SinglePageSalesDbContext(DbContextOptions<SinglePageSalesDbContext> options) : base(options)
        {

        }
        public virtual DbSet<SaleDetails> SalesDetail { get; set; } = null!;
        public virtual DbSet<SaleMasters> SalesMaster { get; set; } = null!;
    }
}
