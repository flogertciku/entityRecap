#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace entityRecap.Models;

public class MyContext : DbContext 
{   
    public MyContext(DbContextOptions options) : base(options) { }      
    public DbSet<User> Users { get; set; } 
}
