using GuardPRO.API.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GuardPRO.API.Database;

public class GuardDbContext : DbContext
{
    public DbSet<Invite> Invites { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<Otdel> Otdels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer("Server=10.0.0.2;User=sa;Password=R1409p1209;Trusted_Connection=true;TrustServerCertificate=true;Integrated Security=false;Database=GuardPRO");
    }
}