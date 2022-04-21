using Microsoft.AspNetCore.Identity;

namespace Store.DataService
{
    public interface IUserService
    {
        IQueryable<IdentityUser> GetUsers();
    }
}
