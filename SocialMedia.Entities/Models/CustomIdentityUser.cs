using Microsoft.AspNetCore.Identity;
using SocialMedia.Core.Abstracts;

namespace SocialMedia.Entities.Models
{
    public class CustomIdentityUser : IdentityUser, IEntity
    {
        public string? ImageUrl { get; set; }
        public bool isOnline { get; set; }
        public DateTime DisconnectTime { get; set; } = DateTime.Now;
        public string? City { get; set; }
        public string ConnectTime { get; set; } = "";
    }
}
