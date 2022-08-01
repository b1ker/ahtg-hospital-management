using HospitalManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Infrastructure
{
    public interface IHospitalManagementDb
    {
        public DbSet<Hospital> Hospitals { get; set; }
    }

    public class HospitalsDb : DbContext, IHospitalManagementDb
    {
        public HospitalsDb(DbContextOptions<HospitalsDb> options) : base(options)
        {
        }

        public DbSet<Hospital> Hospitals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(
                ab =>
                {
                    ab.ToTable("Hospitals");
                });

            modelBuilder.Entity<Hospital>(
                hb=>
                {
                    hb.ToTable("Hospitals");
                    hb.HasOne(h => h.Address).WithOne()
                    .HasForeignKey<Address>(h => h.Id);
                });
            // DataSeed.Seed(modelBuilder);
        }

    }

}