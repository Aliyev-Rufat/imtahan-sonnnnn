using Microsoft.AspNetCore.Identity;

namespace WebApplication15.Models
{

    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
