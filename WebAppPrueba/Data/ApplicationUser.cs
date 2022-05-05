using Microsoft.AspNetCore.Identity;

namespace WebAppPrueba.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
