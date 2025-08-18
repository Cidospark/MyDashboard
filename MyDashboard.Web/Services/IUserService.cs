public interface IUserService
{
    Task<IEnumerable<AppUser>> GetUsersAsync(SearchOptions searchOptions);
    Task<AppUser> GetUserByIdAsync(int id);
}