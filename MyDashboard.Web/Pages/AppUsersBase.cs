using Microsoft.AspNetCore.Components;

public class AppUsersBase : ComponentBase
{
    public IEnumerable<AppUser> AppUsers { get; set; }

    protected override Task OnInitializedAsync()
    {
        LoadUsers();
        return base.OnInitializedAsync();
    }

    private void LoadUsers()
    {
        AppUser e1 = new AppUser
            {
                AppUserId = 1,
                FirstName = "John",
                LastName = "Hastings",
                Email = "David@pragimtech.com",
                DateOfBrith = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                Department = new Department { DepartmentId = 1, DepartmentName = "IT" },
                PhotoPath = "images/john.png"
            };

        AppUser e2 = new AppUser
            {
                AppUserId = 2,
                FirstName = "Sam",
                LastName = "Galloway",
                Email = "Sam@pragimtech.com",
                DateOfBrith = new DateTime(1981, 12, 22),
                Gender = Gender.Male,
                Department = new Department { DepartmentId = 2, DepartmentName = "HR" },
                PhotoPath = "images/sam.jpg"
            };

            AppUser e3 = new AppUser
            {
                AppUserId = 3,
                FirstName = "Mary",
                LastName = "Smith",
                Email = "mary@pragimtech.com",
                DateOfBrith = new DateTime(1979, 11, 11),
                Gender = Gender.Female,
                Department = new Department { DepartmentId = 1, DepartmentName = "IT" },
                PhotoPath = "images/mary.png"
            };

            AppUser e4 = new AppUser
            {
                AppUserId = 3,
                FirstName = "Sara",
                LastName = "Longway",
                Email = "sara@pragimtech.com",
                DateOfBrith = new DateTime(1982, 9, 23),
                Gender = Gender.Female,
                Department = new Department { DepartmentId = 3, DepartmentName = "Payroll" },
                PhotoPath = "images/sara.png"
            };

            AppUsers = new List<AppUser> { e1, e2, e3, e4 };
    }
}