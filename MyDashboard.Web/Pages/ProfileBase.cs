using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

public class ProfileBase : ComponentBase
{
    public AppUser? appUser { get; set; }
    public string buttonText { get; set; } = "Show footer";
    public string toggleBtnClass { get; set; } = "hide-footer";

    [Inject]
    public IUserService _userService { get; set; }

    [Parameter]
    public string id { get; set; } = "";


    protected override async Task OnInitializedAsync()
    {
        id = id ?? "1";
        appUser = await _userService.GetUserByIdAsync(int.Parse(id));
    }

    protected void Toggle_Button()
    {
        if (buttonText == "Hide footer")
        {
            buttonText = "Show footer";
            toggleBtnClass = "hide-footer";
        }
        else
        {
            buttonText = "Hide footer";
            toggleBtnClass = null;
        }
        
    }
}