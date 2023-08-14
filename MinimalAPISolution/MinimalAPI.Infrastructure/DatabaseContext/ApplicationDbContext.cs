using Microsoft.EntityFrameworkCore;
using MinimalAPI.Core.Domain;

namespace MinimalAPI.Infrastructure.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        #region Properties

        public DbSet<Product> Products { get; set; }

        #endregion

        #region Ctors

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");

            modelBuilder.Entity<Product>().HasData(

                new Product()
                {
                    ProductId = Guid.Parse("3e679362-8bb1-42f7-95d2-0da5a620265f"),
                    ProductName = "Chair",
                    ProductQuantity = 6,
                    ProductPrice = 82.9
                },
                new Product()
                {
                    ProductId = Guid.Parse("a8a46194-525f-448d-b274-5a0551c84419"),
                    ProductName = "Dining Table",
                    ProductQuantity = 1,
                    ProductPrice = 322.94
                },
                new Product()
                {
                    ProductId = Guid.Parse("02eebf2b-ab51-4ea5-b2f7-0c2d288a384b"),
                    ProductName = "Table Cloth",
                    ProductQuantity = 1,
                    ProductPrice = 62
                }
            );
        }

        #endregion
    }
}
