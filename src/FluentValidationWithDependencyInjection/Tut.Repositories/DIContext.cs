using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using Tut.Entities;
using Tut.Repositories.Configurations;

namespace Tut.Repositories
{
    public class DIContext : DbContext
    {
        public DIContext() : base("DIContext")
        {

        }

        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Database.SetInitializer(new NullDatabaseInitializer<DbContext>());
            Database.SetInitializer(new DbInitializer());
            modelBuilder.Configurations.Add(new UserProfileConfiguration());
            modelBuilder.Configurations.Add(new BlogConfiguration());
        }

        public override int SaveChanges()
        {
            var modifieldEntites = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                            && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var item in modifieldEntites)
            {
                var entity = item.Entity as IAuditableEntity;
                if (entity == null) continue;
                var identityName = Thread.CurrentPrincipal.Identity.Name;
                var now = DateTime.UtcNow;
                switch (item.State)
                {
                    case EntityState.Added:
                        entity.CreatedBy = identityName;
                        entity.CreatedDate = now;
                        break;
                    case EntityState.Modified:
                        Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                        break;
                }

                entity.UpdatedBy = identityName;
                entity.UpdatedDate = now;
            }
            return base.SaveChanges();
        }
    }
}