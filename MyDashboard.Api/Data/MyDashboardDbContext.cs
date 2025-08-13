using Microsoft.EntityFrameworkCore;

public class MyDashboardDbContext : DbContext
{
    public MyDashboardDbContext(DbContextOptions<MyDashboardDbContext> options)
        : base(options)
    {
    }

    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>().ToTable("AppUsers");
        modelBuilder.Entity<Department>().ToTable("Departments");

        modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 1, DepartmentName = "IT" });
        modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 2, DepartmentName = "HR" });
        modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 3, DepartmentName = "Payroll" });
        
        modelBuilder.Entity<AppUser>().HasData(new AppUser
        {
            AppUserId = 1,
            FirstName = "John",
            LastName = "Hastings",
            Email = "David@pragimtech.com",
            DateOfBrith = new DateTime(1980, 10, 5),
            Gender = Gender.Male,
            DepartmentId = 1,
            PhotoPath = "images/john.png"
        });

        modelBuilder.Entity<AppUser>().HasData(new AppUser
        {
            AppUserId = 2,
            FirstName = "Sam",
            LastName = "Galloway",
            Email = "Sam@pragimtech.com",
            DateOfBrith = new DateTime(1981, 12, 22),
            Gender = Gender.Male,
            DepartmentId = 2,
            PhotoPath = "images/sam.jpg"
        });

            modelBuilder.Entity<AppUser>().HasData(new AppUser
        {
            AppUserId = 3,
            FirstName = "Mary",
            LastName = "Smith",
            Email = "mary@pragimtech.com",
            DateOfBrith = new DateTime(1979, 11, 11),
            Gender = Gender.Female,
            DepartmentId = 1,
            PhotoPath = "images/mary.png"
        });

            modelBuilder.Entity<AppUser>().HasData(new AppUser
        {
            AppUserId = 3,
            FirstName = "Sara",
            LastName = "Longway",
            Email = "sara@pragimtech.com",
            DateOfBrith = new DateTime(1982, 9, 23),
            Gender = Gender.Female,
            DepartmentId = 3,
            PhotoPath = "images/sara.png"
        });
    }
}