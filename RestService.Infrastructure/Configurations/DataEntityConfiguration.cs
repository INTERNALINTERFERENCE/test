using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestService.Infrastructure.Entities;

namespace RestService.Infrastructure.Configurations;

public class DataEntityConfiguration : BaseEntityConfiguration<DataEntity>
{
    public override void Configure(EntityTypeBuilder<DataEntity> builder)
    {
        base.Configure(builder);
        builder.Property(p => p.Value).HasMaxLength(1000);
    }
}