
internal class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
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
}