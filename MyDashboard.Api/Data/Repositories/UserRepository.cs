
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly MyDashboardDbContext _myDashboardDbContext;
    public UserRepository(MyDashboardDbContext myDashboardDbContext)
    {
        _myDashboardDbContext = myDashboardDbContext;
    }

    public async Task<AppUser> AddAppUserAsync(AppUser user)
    {
        var result = await _myDashboardDbContext.AppUsers.AddAsync(user);
        await _myDashboardDbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task DeleteAppUserAsync(int userId)
    {
        var AppUser = await GetAppUserAsync(userId);
        if (AppUser != null)
        {
            _myDashboardDbContext.Remove(AppUser);
            await _myDashboardDbContext.SaveChangesAsync();
        }
    }

    public async Task<AppUser> GetAppUserAsync(int userId)
    {
        return await _myDashboardDbContext.AppUsers.FirstOrDefaultAsync(u => u.AppUserId == userId);
    }

    public async Task<AppUser> GetAppUserByEmailAsync(string email)
    {
        return await _myDashboardDbContext.AppUsers.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return await _myDashboardDbContext.AppUsers.ToListAsync();
    }

    public async Task<AppUser> UpdateAppUserAsync(AppUser user)
    {
        var result = await GetAppUserAsync(user.AppUserId);
        if (result != null)
        {
            result.FirstName = user.FirstName;
            result.LastName = user.LastName;
            result.Email = user.Email;
            result.DateOfBrith = user.DateOfBrith;
            user.PhotoPath = user.PhotoPath;

            await _myDashboardDbContext.SaveChangesAsync();
            return result;
        }

        return null;
    }
}