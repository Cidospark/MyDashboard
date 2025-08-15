public interface IUserRepository
{
    Task<IEnumerable<AppUser>> GetUsers();
    Task<AppUser> GetAppUser(int userId);
    Task<AppUser> AddAppUser(AppUser user);
    Task<AppUser> UpdateAppUser(AppUser user);
    Task DeleteAppUser(int userId);
}