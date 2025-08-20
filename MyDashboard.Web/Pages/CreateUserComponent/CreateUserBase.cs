using AutoMapper;
using Microsoft.AspNetCore.Components;

public class CreateUserBase : ComponentBase
{
    public AddUserDto AddUserDto { get; set; } = new AddUserDto();

    protected string EmailAlreayExistsErrMsg = "";

    [Inject]
    public IUserService _userService { get; set; }
    [Inject]
    public IMapper Mapper { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {

    }

    protected async Task HandleValidSubmit()
    {
        var users = await _userService.GetUsersAsync(new SearchOptions());
        if (users != null && users.Any(e => e.Email == AddUserDto.Email))
        {
            EmailAlreayExistsErrMsg = "Email already exists!";
        }
        else
        {
            var nextId = users.Count() + 1;
            while (users.Select(u => u.AppUserId).ToArray().Contains(nextId))
            {
                nextId += 1;
            }
            var newUser = Mapper.Map<AppUser>(AddUserDto);
            newUser.AppUserId = nextId;
            newUser.DateOfBrith = new DateTime(newUser.DateOfBrith.Year, newUser.DateOfBrith.Month, newUser.DateOfBrith.Day).ToUniversalTime();

            await _userService.AddUserAsync(newUser);
            NavigationManager.NavigateTo("/users");
        }
        
    }
}