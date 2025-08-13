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

        AppUsers = new List<AppUser> {  };
    }
}