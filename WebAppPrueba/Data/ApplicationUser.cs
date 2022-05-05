using Microsoft.AspNetCore.Identity;

namespace WebAppPrueba.Data
{
    public class ApplicationUser : IdentityUser
    {
       
        public string Password { get; set; }
    }
}
