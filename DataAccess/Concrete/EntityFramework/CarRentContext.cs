using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    // Context : Db tabloları ile proje classlarını bağlamak.
    public class CarRentContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CarRent;Trusted_Connection=true");
        }
        public DbSet<Car> Cars { get; set; } // benim Car clasım veri tabanındaki Cars tablosuna karşı geliyor.
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
