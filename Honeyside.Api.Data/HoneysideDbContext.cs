using Honeyside.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Honeyside.Api.Data
{
    public class HoneysideDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<EvCharge> EvCharges { get; set; }
        public DbSet<EvChargeStation> EvChargeStations { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
