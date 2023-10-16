using Microsoft.EntityFrameworkCore;

namespace BillingSystem.Models
{
    public class BillingContext : DbContext
    {
        public BillingContext(DbContextOptions<BillingContext> options) : base(options)
        {
        }

        public DbSet<BillRecord> BillRecords { get; set; }
    }
}
