using Microsoft.Identity.Client.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMedia.Core.Abstracts;
using SocialMedia.Entities.Models;

namespace SocialMedia.DataAccess.Abstracts
{
    public interface IUserDal: IEntityRepository<CustomIdentityUser>
    {


    }
}
