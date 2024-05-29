using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Manager.Domain.Entities
namespace Manager.Infra.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

         builder.HasKey(x => x.Id);

		 builder.Property(x => x.Id)
			 .ValueGenerateOnAdd()
			 .HasColumnType("BIGINT");

	      builder.property(x => x.Name)
		      .IsRequired()
		      .HasMaxLength("50")
		      .HasColumnName("Name")
		      .HasColumnType("VARCHAR(50)");
	      
		   builder.property(x => x.Email)
			   .IsRequired()
			   .HasMaxLength("50")
			   .HasColumnName("Email")
			   .HasColumnType("VARCHAR(50)");

		   builder.property(x => x.Password)
			   .IsRequired()
			   .HasMaxLength("50")
			   .HasColumnName("Password")
			   .HasColumnType("VARCHAR(30)");

		   builder.property(x => x.CreateAt)
			   .IsRequired()
			   .HasColumnType("DATETIME")
			   .HasDefaultSql("GETDATE()");
		   
		   builder.property(x=>x.UpdateAt)
			   .IsRequired()
			   .HasColumnType("DATETIME")
			   .HasDefaultSql("GETDATE()");
		   
		   builder.property(x=>x.UpdateAt)
			   .ValueGenerateOnAdd()
			   .HasComputedColumnSql("GETDATE()");
    }
}