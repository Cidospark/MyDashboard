using System.ComponentModel.DataAnnotations;

public class EditUserDto
{

    public int AppUserId { get; set; }
    [Required(ErrorMessage = "First name is required!")]
    [StringLength(15, MinimumLength = 2, ErrorMessage = "MinLen = 2, MaxLen 15.")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last name is required!")]
    [StringLength(15, MinimumLength = 2, ErrorMessage = "MinLen = 2, MaxLen 15.")]
    public string LastName { get; set; } = string.Empty;

    public DateTime DateOfBrith { get; set; }
    public Gender Gender { get; set; }
}