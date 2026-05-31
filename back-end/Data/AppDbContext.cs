using Microsoft.EntityFrameworkCore;
using Models.User;
namespace Data.AppDbContext;
public class AppDbContext : DbContext
{
    public DbSet<User> Users {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  
        => optionsBuilder
            .UseSqlServer("Server=localhost\\SQLSTEVAN;Database=Auth_System_DB;Trusted_Connection=True;TrustServerCertificate=True;")
            .LogTo(Console.WriteLine, LogLevel.Information);
}


