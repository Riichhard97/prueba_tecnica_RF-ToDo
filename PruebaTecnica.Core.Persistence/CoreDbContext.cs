using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using PruebaTecnica.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Persistence
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Activity> Activity { get; set; }
        public DbSet<Goal> Goal { get; set; }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entityEntry in ChangeTracker.Entries())
            {
                if (entityEntry.State == EntityState.Added)
                {
                    if (entityEntry.Entity is IEntityBase entityBase)
                    {
                        entityBase.DateCreated = DateTime.UtcNow;
                        entityBase.DateUpdated = DateTime.UtcNow;

                    }

                    OnBeforeAdd(entityEntry);
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    if (entityEntry.Entity is IEntityBase entityBase)
                    {
                        entityBase.DateUpdated = DateTime.UtcNow;
                    }

                    OnBeforeUpdate(entityEntry);
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected virtual void ConfigureEntity(ModelBuilder modelBuilder, IMutableEntityType entity)
        {
        }

        protected virtual void OnBeforeAdd(EntityEntry entityEntry)
        {
        }

        protected virtual void OnBeforeUpdate(EntityEntry entityEntry)
        {
        }
    }
}
