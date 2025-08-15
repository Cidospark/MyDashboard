using Microsoft.EntityFrameworkCore;

public class MyDashboardDbContext : DbContext
{
    public MyDashboardDbContext(DbContextOptions<MyDashboardDbContext> options)
        : base(options)
    {
    }

    public DbSet<AppUser> AppUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}