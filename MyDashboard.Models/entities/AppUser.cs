public class AppUser
{
    public int AppUserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime DateOfBrith { get; set; }
    public Gender Gender { get; set; }
    public int DepartmentId { get; set; }
    public string PhotoPath { get; set; } = string.Empty;

    // Navigation property to Department
    public Department? Department { get; set; }
}