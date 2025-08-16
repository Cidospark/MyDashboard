
internal class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync(SearchOptions searchOptions)
    {
        try
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseDto<IEnumerable<AppUser>>>($"/api/users?FirstName={searchOptions.FirstName}&Gender={searchOptions.Gender}");
            return result.Data;
        }
        catch (Exception ex)
        {
            throw;
        }
        // return new List<AppUser>
        // {
        //     new AppUser
        //     {
        //         AppUserId = 2,
        //         FirstName = "Sam",
        //         LastName = "Galloway",
        //         Email = "Sam@pragimtech.com",
        //         DateOfBrith = new DateTime(1981, 12, 22),
        //         Gender = Gender.Male,
        //         PhotoPath = "images/sam.jpg"
        //     }
        // };

    }
}