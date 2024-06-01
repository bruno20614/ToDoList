using Microsoft.EntityFrameworkCore;
using Manager.Infra.Mappings;

namespace Manager.Infra.Context;

public class ManagerContext : DbContext
{
    public ManagerContext()
    {
        
    }

    public ManagerContext(DbContextOptions<ManagerContext> options) 
        : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=PCBRUNO\\SQLEXPRESS;Database=USERMANAGERAPI;Integrated Security=SSPI;TrustServerCertificate=True;trusted_connection=true");
    }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserMap());
    }
}