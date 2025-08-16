public interface IUserService
{
    Task<IEnumerable<AppUser>> GetUsersAsync(SearchOptions searchOptions);
}