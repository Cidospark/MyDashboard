
internal class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddUserAsync(AppUser user)
    {
        await _httpClient.PostAsJsonAsync($"api/users/", user);
    }

    public async Task<AppUser> GetUserByIdAsync(int id)
    {
        var result = await _httpClient.GetFromJsonAsync<ResponseDto<AppUser>>($"/api/users/{id}");
        return result.Data;
    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync(SearchOptions searchOptions)
    {
        var result =  await _httpClient.GetFromJsonAsync<ResponseDto<IEnumerable<AppUser>>>($"/api/users?FirstName={searchOptions.FirstName}&Gender={searchOptions.Gender}");
        return result.Data;
    }

    public async Task UpdateUserAsync(AppUser user)
    {
        await _httpClient.PutAsJsonAsync($"api/users/{user.AppUserId}", user);
    }
}