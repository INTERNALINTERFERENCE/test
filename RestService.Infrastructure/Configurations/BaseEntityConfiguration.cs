using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestService.Infrastructure.Entities;

namespace RestService.Infrastructure.Configurations;

public class BaseEntityConfiguration<TEntity>
    : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
    }
}