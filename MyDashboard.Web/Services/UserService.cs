
internal class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync(SearchOptions searchOptions)
    {
        var result =  await _httpClient.GetFromJsonAsync<ResponseDto<IEnumerable<AppUser>>>($"/api/users?FirstName={searchOptions.FirstName}&Gender={searchOptions.Gender}");
        return result.Data;
    }
}