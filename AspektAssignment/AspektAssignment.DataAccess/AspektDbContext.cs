using AspektAssignment.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AspektAssignment.DataAccess
{
    public class AspektDbContext : DbContext
    {
        public AspektDbContext(DbContextOptions options) : base(options) { }

        //Tables
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Contact> Contacts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relations

            modelBuilder.Entity<Company>()
                .HasMany(x => x.Contacts)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId);

            modelBuilder.Entity<Country>()
                .HasMany(x => x.Contacts)
                .WithOne(x => x.Country)
                .HasForeignKey(x => x.CountryId);

            // Constraints



            // Seeding

            modelBuilder.Entity<Company>().HasData(
                new Company() { Id = 1, Name = "Apple"},
                new Company() { Id = 2, Name = "Google" },
                new Company() { Id = 3, Name = "Amazon" },
                new Company() { Id = 4, Name = "Microsoft" },
                new Company() { Id = 5, Name = "Tesla" });

            modelBuilder.Entity<Country>().HasData(
                new Country() { Id = 1, Name = "Macedonia"},
                new Country() { Id = 2, Name = "Holland" },
                new Country() { Id = 3, Name = "USA" },
                new Country() { Id = 4, Name = "France" },
                new Country() { Id = 5, Name = "Spain" });

            modelBuilder.Entity<Contact>().HasData(
                new Contact() { Id = 1, Name = "Contact1", CompanyId = 1, CountryId = 1 },
                new Contact() { Id = 2, Name = "Contact2", CompanyId = 2, CountryId = 1 },
                new Contact() { Id = 3, Name = "Contact3", CompanyId = 3, CountryId = 2 },
                new Contact() { Id = 4, Name = "Contact4", CompanyId = 2, CountryId = 2 },
                new Contact() { Id = 5, Name = "Contact5", CompanyId = 4, CountryId = 5 },
                new Contact() { Id = 6, Name = "Contact6", CompanyId = 5, CountryId = 1 },
                new Contact() { Id = 7, Name = "Contact7", CompanyId = 1, CountryId = 1 },
                new Contact() { Id = 8, Name = "Contact8", CompanyId = 2, CountryId = 1 },
                new Contact() { Id = 9, Name = "Contact9", CompanyId = 3, CountryId = 2 },
                new Contact() { Id = 10, Name = "Contact10", CompanyId = 2, CountryId = 2 },
                new Contact() { Id = 11, Name = "Contact11", CompanyId = 4, CountryId = 5 },
                new Contact() { Id = 12, Name = "Contact12", CompanyId = 5, CountryId = 1 },
                new Contact() { Id = 13, Name = "Contact13", CompanyId = 5, CountryId = 2 },
                new Contact() { Id = 14, Name = "Contact14", CompanyId = 4, CountryId = 5 },
                new Contact() { Id = 15, Name = "Contact15", CompanyId = 5, CountryId = 1 }
                );
        }

    }
}
