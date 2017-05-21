using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Tut.Entities;

namespace Tut.Repositories.Configurations
{
    public class BlogConfiguration : EntityTypeConfiguration<Blog>
    {
        public BlogConfiguration()
        {
            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Owner).HasMaxLength(50).IsRequired();
            Property(x => x.Name).HasMaxLength(100).IsRequired();
            Property(x => x.Url).HasMaxLength(200).IsRequired();
            Property(x => x.UserId).IsRequired().HasColumnName("UserId");

            Property(x => x.CreatedBy).HasMaxLength(50);
            Property(x => x.CreatedDate).IsRequired();
            Property(x => x.UpdatedBy).HasMaxLength(50);
            Property(x => x.UpdatedDate).IsRequired();
        }
    }
}