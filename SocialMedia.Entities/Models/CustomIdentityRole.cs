using Microsoft.AspNetCore.Identity;
using SocialMedia.Core.Abstracts;

namespace SocialMedia.Entities.Models
{
    public class CustomIdentityRole : IdentityRole, IEntity
    {
    }
}
