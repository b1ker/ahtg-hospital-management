using HospitalManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Infrastructure
{
    public static class DataSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var FirstAddress = new Address
            {
                Id = new Guid("5da668b5-6203-41fc-b1de-69a6c8168200"),
                AddressLine1 = "1 Arapaho Street",
                State = "TX",
                ZipCode = "75000",
                City = "Plano"
            };

            var SecondAddress = new Address
            {
                Id = new Guid("8279c373-00e8-45e3-850c-e12fd0b45bfb"),
                AddressLine1 = "9500 Euclid Avenue,",
                State = "OH",
                ZipCode = "44195-5108",
                City = "Clevland"
            };

            var ThirdAddress = new Address
            {
                Id = new Guid("6e6f67a7-6746-40c2-a6fe-175ad71eae42"),
                AddressLine1 = "1216 Second Street SW",
                State = "MN",
                ZipCode = "55902-1906",
                City = "Rochester"
            };

            var FirstHospital = new Hospital
            {
                Id = new Guid("5da668b5-6203-41fc-b1de-69a6c8168200"),
                Name = "Plano General Hospital",
                Description = "General hospital in Plano",
                Address = new Address
                { AddressLine1 = "1 Arapaho Street",
                }

            };
            /*
            var SecondHospital = new Hospital
            {
                Id = new Guid("c212d071-f046-4dca-a98f-eabd6e94593c"),
                Name = "Cleveland Clinic",
                Description = "General hospital in Cleveland. Ranked one of the best in the nation for cardiology procedures.",
                Address = SecondAddress
            };

            var ThirdHospital = new Hospital
            {
                Id = new Guid("b9236b03-0d30-40dc-846e-30f3d812dd4e"),
                Name = "Mayo Clinic",
                Description = "Mayo Clinic in Rochester, MN is ranked No. 1 on the Best Hospitals Honor Roll.",
                Address = ThirdAddress
            };
            */

            modelBuilder.Entity<Hospital>().HasData(FirstHospital); //, SecondHospital, ThirdHospital);
        }

    }
}

