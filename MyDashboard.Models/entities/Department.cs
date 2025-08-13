public class Department
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;

    // Navigation property to AppUsers
    public AppUser? AppUsers { get; set; }
}