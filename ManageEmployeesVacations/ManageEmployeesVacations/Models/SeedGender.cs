using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageEmployeesVacations.Models
{
    public class SeedGender : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasData
           (
               new Gender
               {
                   GenderId = 1,
                   GenderType = "Female",

               },
               new Gender
               {
                   GenderId = 2,
                   GenderType = "Male",

               },
                 new Gender
                 {
                     GenderId = 3,
                     GenderType = "Other",

                 }
           );
        }
    }
}
