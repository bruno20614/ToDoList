using Microsoft.EntityFrameworkCore;
using Manager.Infra.Mappings;

namespace Manager.Infra.Context;

public class ManagerContext : DbContext
{
    public ManagerContext()
    {
        
    }
    
    public ManagerContext(DbContextOptions)
}