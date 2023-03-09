using GuardPRO.API7.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace GuardPRO.API7.Database;

public class GuardDbContext : DbContext
{
    public GuardDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Invite> Invites { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<Otdel> Otdels { get; set; }
}