using Microsoft.AspNetCore.Components;

public class EditProfileBase : ComponentBase
{
    [Inject]
    public IUserService _userService { get; set; }

    public AppUser? appUser { get; set; } = new AppUser();

    [Parameter]
    public string id { get; set; } = "";

    protected override async Task OnInitializedAsync()
    {
        id = id ?? "1";
        appUser = await _userService.GetUserByIdAsync(int.Parse(id));
    }
}