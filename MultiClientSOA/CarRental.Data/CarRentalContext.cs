using CarRental.Business.Entities;
using Core.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace CarRental.Data
{
    public class CarRentalContext : DbContext
    {
        public CarRentalContext()
        {

        }
        public CarRentalContext(DbContextOptions<CarRentalContext> options) : base(options)
        {

        }

        public DbSet<Account> AccountSet { get; set; }
        public DbSet<Car> CarSet { get; set; }
        public DbSet<Rental> RentalSet { get; set; }
        public DbSet<Reservation> Reservation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            modelBuilder.Entity<Account>().HasKey(a => a.AccountId);
            modelBuilder.Entity<Car>().HasKey(c => c.CarId);
            modelBuilder.Entity<Rental>().HasKey(r => r.RentalId);
            modelBuilder.Entity<Reservation>().HasKey(r => r.ReservationId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
