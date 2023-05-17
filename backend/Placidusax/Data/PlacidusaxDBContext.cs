using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Placidusax.Data.DBModels;

namespace Placidusax.Data;

public class PlacidusaxDbContext : IdentityDbContext<User>
{
    public PlacidusaxDbContext(DbContextOptions<PlacidusaxDbContext> options)
    : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }
}
