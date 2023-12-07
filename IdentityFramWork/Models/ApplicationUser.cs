using Microsoft.AspNetCore.Identity;

namespace IdentityFramWork.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TRN { get; set; }
        public int UserNameChangeCount { get; set; } = 5;

        public byte[]? ProfileImage { get; set; }

    }
}
