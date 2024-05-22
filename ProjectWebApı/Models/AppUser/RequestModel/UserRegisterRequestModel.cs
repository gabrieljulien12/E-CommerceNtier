using System.ComponentModel.DataAnnotations;

namespace ProjectWebApı.Models.AppUser.RequestModel
{
    public class UserRegisterRequestModel
    {
        public string UserName { get; set; }    
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirimPassword { get; set; }
        public string Email { get; set; }   
       
    }
}
