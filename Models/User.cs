using Microsoft.AspNetCore.Identity;
namespace GoogleBooksApp.Models
{
    public class User : IdentityUser
    {
        public int? UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; } //Note: Always hash and salt your passwords

        // Navigation property
        public ICollection<FavoriteBook>? FavoriteBooks { get; set; }
    }
}
