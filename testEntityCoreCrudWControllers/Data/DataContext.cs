using Microsoft.EntityFrameworkCore;
using testEntityCoreCrudWControllers.Entities;

namespace testEntityCoreCrudWControllers.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    
}