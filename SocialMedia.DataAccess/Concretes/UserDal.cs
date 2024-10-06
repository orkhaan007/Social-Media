using SocialMedia.Core.Concretes;
using SocialMedia.DataAccess.Abstracts;
using SocialMedia.Entities.Models;

namespace SocialMedia.DataAccess.Concretes
{
    public class UserDal : EFEntityRepositoryBase<CustomIdentityUser, SocialMediaDBContext>, IUserDal
    {
        public UserDal(SocialMediaDBContext context) : base(context)
        {

        }
    }
}
