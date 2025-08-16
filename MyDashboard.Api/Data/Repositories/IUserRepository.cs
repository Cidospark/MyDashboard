public interface IUserRepository
{
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<AppUser> GetAppUserAsync(int userId);
    Task<AppUser> GetAppUserByEmailAsync(string email);
    Task<AppUser> AddAppUserAsync(AppUser user);
    Task<AppUser> UpdateAppUserAsync(AppUser user);
    Task DeleteAppUserAsync(int userId);
}