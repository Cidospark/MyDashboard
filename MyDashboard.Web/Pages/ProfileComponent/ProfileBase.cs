using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;

public class ProfileBase : ComponentBase
{
    public AppUser? appUser { get; set; }
    public string buttonText { get; set; } = "Manage details";
    public bool buttonState { get; set; } = true;
    public string toggleBtnClass { get; set; } = "hide";

    public Dictionary<string, object> AttributeSplattingFromParent { get; set; } = new Dictionary<string, object>(){
                {"Title", "Confirm Delete."},
                {"Text", "Please confirm your action to delete user."}
            };

    [Inject]
    public IUserService _userService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string id { get; set; } = "";

    [Inject]
    public IJSRuntime JsRuntime { get; set; }


    protected ConfirmBase _delDialog { get; set; }


    protected override async Task OnInitializedAsync()
    {
        id = id ?? "1";
        appUser = await _userService.GetUserByIdAsync(int.Parse(id));
        if (appUser != null)
        {
            AttributeSplattingFromParent = new Dictionary<string, object>
            {
                {"Title", "Confirm Delete."},
                {"Text", $"Please confirm your action to delete user - {appUser.FirstName} {appUser.LastName} "}
            };
        }
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
            toggleBtnClass = "hide";
        }

    }

    protected async Task DeleteUser()
    {
        await _userService.DeleteAsync(appUser.AppUserId);
        NavigationManager.NavigateTo("/users");
    }

    protected void OpenDeleteConfirmationModal()
    {
        _delDialog.OpenDeleteConfirmationModal();
    }

    protected async Task GoBack()
    {
        await JsRuntime.InvokeVoidAsync("history.back");
    }
}