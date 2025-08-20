public interface IUserService
{
    Task<IEnumerable<AppUser>> GetUsersAsync(SearchOptions searchOptions);
    Task<AppUser> GetUserByIdAsync(int id);
    Task UpdateUserAsync(AppUser user);
    Task AddUserAsync(AppUser user);
    Task DeleteAsync(int userId);
}