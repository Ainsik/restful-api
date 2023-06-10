using core.Entities;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.DbContext;

public class RestDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public RestDbContext(DbContextOptions<RestDbContext> options) : base(options)
    {

    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Doctor> Doctors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}