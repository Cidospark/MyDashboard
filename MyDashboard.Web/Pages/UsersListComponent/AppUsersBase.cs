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
        AppUsers = await _userService.GetUsersAsync(options);
    }
}