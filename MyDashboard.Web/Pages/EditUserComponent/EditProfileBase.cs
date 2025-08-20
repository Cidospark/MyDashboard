using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

public class EditProfileBase : ComponentBase
{
    [Inject]
    public IUserService _userService { get; set; }

    [Inject]
    public IMapper Mapper { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public IJSRuntime JsRuntime { get; set; }
    

    public EditUserDto EditUserDto { get; set; } = new EditUserDto();

    public AppUser? appUser { get; set; } = new AppUser();

    [Parameter]
    public string id { get; set; } = "";

    protected override async Task OnInitializedAsync()
    {
        id = id ?? "1";
        appUser = await _userService.GetUserByIdAsync(int.Parse(id));
        Mapper.Map(appUser, EditUserDto);
    }

    protected async Task HandleValidSubmit()
    {
        Mapper.Map(EditUserDto, appUser);
        await _userService.UpdateUserAsync(appUser);
        NavigationManager.NavigateTo("/users");
    }

    protected async Task GoBack()
    {
        await JsRuntime.InvokeVoidAsync("history.back");
    }
}