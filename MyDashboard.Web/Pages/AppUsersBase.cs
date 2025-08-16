using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

public class AppUsersBase : ComponentBase
{
    public IEnumerable<AppUser> AppUsers { get; set; }

    [Inject]
    public IUserService _userService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await LoadUsersAsync();
    }

    private async Task LoadUsersAsync()
    {
        var options = new SearchOptions
        {
            FirstName = "",
            Gender = 0
        };
        try
        {
            AppUsers = await _userService.GetUsersAsync(options);
        }
        catch(Exception ex)
        {
            throw;
        }
        // AppUsers = new List<AppUser>
        // {
        //     new AppUser
        //     {
        //         AppUserId = 2,
        //         FirstName = "Sam",
        //         LastName = "Galloway",
        //         Email = "Sam@pragimtech.com",
        //         DateOfBrith = new DateTime(1981, 12, 22),
        //         Gender = Gender.Male,
        //         PhotoPath = "images/sam.jpg"
        //     }
        // };
        }
}