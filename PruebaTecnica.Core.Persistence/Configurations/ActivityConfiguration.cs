using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Core.Domain.Entities;

namespace PruebaTecnica.Core.Persistence.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.Property(x => x.Id)
                .UseIdentityColumn();
        }
    }
}
