using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Models
{
    public class SeedUser : IEntityTypeConfiguration<User>
    {
        void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
               new User
               {
                   UserId = 1,
                   Name = "rowan",
                   Password = "123",
                   Email = "rowan",
                   CreatedDate = DateTime.Now,
               }
                );
        }
    }
}
