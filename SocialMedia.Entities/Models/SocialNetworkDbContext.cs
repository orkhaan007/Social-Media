using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Entities.Models
{
    public class SocialMediaDBContext : IdentityDbContext<CustomIdentityUser, CustomIdentityRole, string>
    {
        public SocialMediaDBContext(DbContextOptions<SocialMediaDBContext> options) : base(options)
        {

        }

    }
}
