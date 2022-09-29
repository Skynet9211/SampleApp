using Microsoft.EntityFrameworkCore;
using SampleApp.Models;

namespace SampleApp.Data
{
    public class ApplicationdbContext:DbContext
    {
        public ApplicationdbContext(DbContextOptions<ApplicationdbContext>options):base(options)
        {

        }
            public virtual DbSet<Product> Product { get; set; } 
            public virtual DbSet<Customer> Customer { get; set; }
            public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<spSales> Salereport { get; set; }


    }
}
