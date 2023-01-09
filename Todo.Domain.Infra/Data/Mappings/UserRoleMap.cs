using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Entitys;

namespace Todo.Domain.Infra.Data.Mappings;


public class UserRoleMap : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRole");

        builder.HasKey(x => new { x.RoleName, x.UserEmail });

        builder
        .HasOne(x => x.User)
        .WithMany(x => x.UserRoles)
        .HasForeignKey(x => x.UserEmail);

        builder
        .HasOne(x => x.Role)
        .WithMany(x => x.UserRoles)
        .HasForeignKey(x => x.RoleName);

    }
}