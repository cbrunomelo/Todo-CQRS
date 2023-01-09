using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Entitys;


namespace Todo.Domain.Infra.Data.Mappings;

public class TodoMap : IEntityTypeConfiguration<Todo.Domain.Entitys.Todo>
{
    public void Configure(EntityTypeBuilder<Todo.Domain.Entitys.Todo> builder)
    {
        builder.ToTable("Todo");


        builder.HasKey(x => new { x.Title, x.Email });



        builder.Property(x => x.Title)
        .IsRequired()
        .HasColumnName("Title")
        .HasColumnType("NVARCHAR")
        .HasMaxLength(30);


        builder.Property(x => x.CreatedAt)
        .IsRequired()
        .HasColumnName("CreatedAt")
        .HasColumnType("SMALLDATETIME")
        .HasMaxLength(60)
        .HasDefaultValue(DateTime.Now.ToUniversalTime());

        builder.Property(x => x.LastUpdate)
        .IsRequired()
        .HasColumnName("LastUpdate")
        .HasColumnType("SMALLDATETIME")
        .HasMaxLength(60)
        .HasDefaultValue(DateTime.Now.ToUniversalTime());


        builder.Property(x => x.Done)
        .IsRequired()
        .HasColumnName("Done")
        .HasColumnType("BIT");

        builder
        .HasOne(x => x.User)
        .WithMany(x => x.Todos)
        .HasForeignKey(x => x.Email);





    }
}

