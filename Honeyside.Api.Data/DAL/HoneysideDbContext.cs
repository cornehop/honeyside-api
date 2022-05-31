using Honeyside.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Honeyside.Api.Data.DAL
{
    /// <summary>
    /// Database context for the Honeyside API
    /// </summary>
    public class HoneysideDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<EvCharge> EvCharges { get; set; }
        public DbSet<EvChargingStation> EvChargingStations { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HoneysideDbContext"/> class
        /// </summary>
        /// <param name="options">Database context options</param>
        public HoneysideDbContext(DbContextOptions<HoneysideDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EvCharge>()
                .Property(charge => charge.Price)
                .HasPrecision(5, 2);

            modelBuilder.Entity<EvCharge>()
                .Property(charge => charge.Kwh)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Invoice>()
                .Property(invoice => invoice.Amount)
                .HasPrecision(10, 2);
        }
    }
}
