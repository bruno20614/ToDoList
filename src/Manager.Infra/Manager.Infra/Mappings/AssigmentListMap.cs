using Microsoft.EntityFrameworkCore;
using  Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Infra.Mappings;

public class AssigmentListMap : IEntityTypeConfiguration<AssigmentList>
{
    public void(EntityTypeBuilder<AssigmentList> builder)
    {
        builder.ToTable("AssigmentList");
        
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .IValueGenerateOnAdd()
            .HascColumnName("Id")
            .HasColumnType("BIGINT");

        builder.Property(u => u.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("BIGINT");
        
        builder.Property(u => u.UserId)
            .IsRequired()
            .HasColumnName("UserId");
        
        builder
            .HasMany(u => u.Assignments)
            .WithOne(u => u.AssignmentList)
            .OnDelete(DeleteBehavior.Restrict);

    } 
}