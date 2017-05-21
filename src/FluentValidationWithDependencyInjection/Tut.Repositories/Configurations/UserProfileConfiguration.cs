using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Tut.Entities;

namespace Tut.Repositories.Configurations
{
    public class UserProfileConfiguration : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileConfiguration()
        {
            HasKey(a => a.Id)
                .Property(a => a.Id)
                .HasColumnName("UserId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(a => a.Email).HasMaxLength(50);
            Property(a => a.UserName).IsRequired().HasMaxLength(50);

            Property(x => x.CreatedBy).HasMaxLength(50);
            Property(x => x.CreatedDate).IsRequired();
            Property(x => x.UpdatedBy).HasMaxLength(50);
            Property(x => x.UpdatedDate).IsRequired();
        }
    }
}