using Microsoft.EntityFrameworkCore;
using  Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Mappings;

public class AssignmentMap : IEntityTypeConfiguration<Assigment>
{
    public void Configure(EntityTypeBuilder<Assigment> builder)
    {
        builder.ToTable("Assigment");

        builder.HasKey(y => y.Id);

        builder.Property(y => y.Id)
            .IValueGenerateOnAdd()
            .HascColumnName("Id")
            .HasColumnType("BIGINT");

        builder.Property(y => y.Description)
            .IsRequired()
            .HasMaxLength("100")
            .HasColumnName("Description")
            .HasColumnType("VARCHAR(30)");

        builder.Property(y => y.UserId)
            .IsRequired()
            .HasColumnName("UserId");

        builder.Property(y => y.AssigmentListId)
            .IsRequired(false)
            .HasColumnName("AssigmentListId");
            
        builder.Property(y => y.Concluded)
            .IsRequired();
            .HasColumnName("Concluded")
            .HasDefaultValue(false)
            .HasColumnType("TINYINTT);

        builder.Property(y => y.DeadLine)
            .IsRequired()
            .HasColumnName("DeadLine")
            .HasColumnType("DATETIME")
            
        builder
            .Property(y => y.ConcludedAt)
            .HasColumnType("DATETIME")
            .IsRequired();
    
        builder
            .Property(y=> y.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasColumnType("DATETIME");
        
        builder
            .Property(y => y.UpdatedAt)
            .ValueGeneratedOnAddOrUpdate()
            .HasColumnType("DATETIME");
    
    } 
}