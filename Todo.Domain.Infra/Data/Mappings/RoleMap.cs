using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Entitys;

namespace Todo.Domain.Infra.Data.Mappings;


public class RoleMap : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");

        builder.HasKey(x => x.Name);

        builder.Property(x => x.Name).IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

        builder
                .HasMany(x => x.UserRoles)
                .WithOne(x => x.Role);
    }
}