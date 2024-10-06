using System.Linq.Expressions;
using SocialMedia.Entities.Models;

namespace SocialMedia.Business.Abstrats
{
    public interface IUserService
    {
        Task<CustomIdentityUser> GetAsync(Expression<Func<CustomIdentityUser, bool>> filter);
        Task<List<CustomIdentityUser>> GetListAsync(Expression<Func<CustomIdentityUser, bool>> filter = null);
        Task DeleteListAsync(List<CustomIdentityUser> entities);
        Task DeleteAsync(CustomIdentityUser entity);
        Task AddAsync(CustomIdentityUser entity);
        Task UpdateAsync(CustomIdentityUser entity);
    }
}
