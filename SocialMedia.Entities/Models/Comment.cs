namespace SocialMedia.Entities.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Content { get; set; } 
        public DateTime CreationDate { get; set; } = DateTime.Now; 
        public string UserId { get; set; }
        public virtual CustomIdentityUser User { get; set; }
        public int PostId { get; set; } 
        public virtual Post Post { get; set; }

    }
}
