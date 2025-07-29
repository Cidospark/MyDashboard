public class AppUser
{
    public int AppUserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBrith { get; set; }
    public Gender Gender { get; set; }
    public Department Department { get; set; }
    public string PhotoPath { get; set; }
}