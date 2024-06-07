using Microsoft.EntityFrameworkCore;
using Manager.Infra.Mappings;
using Manager.Domain.Entities;

namespace Manager.Infra.Context
{
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
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=PCBRUNO\\SQLEXPRESS;Database=USERMANAGERAPI;Integrated Security=SSPI;TrustServerCertificate=True;trusted_connection=true");
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentList> AssignmentLists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(modelBuilder);
            
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new AssignmentMap());
            builder.ApplyConfiguration(new AssignmentListMap());
        }
    }
}
