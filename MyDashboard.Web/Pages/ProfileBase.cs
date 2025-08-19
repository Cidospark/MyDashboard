using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

public class ProfileBase : ComponentBase
{
    public AppUser? appUser { get; set; }
    public string buttonText { get; set; } = "Manage details";
    public bool buttonState { get; set; } = true;
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
        if (buttonState)
        {
            buttonState = false;
            toggleBtnClass = null;
        }
        else
        {
            buttonState = true;
            toggleBtnClass = "hide-footer";
        }
        
    }
}