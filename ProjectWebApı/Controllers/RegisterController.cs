using Entıtıes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectBLL.ManagerServices.Abstracs;
using ProjectWebApı.Models.AppUser.RequestModel;

namespace ProjectWebApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
         IAppUserManger _appUserManger;

        public RegisterController( IAppUserManger appUserManger)
        {
            _appUserManger = appUserManger;
        }

        [HttpPost]
        public async Task<IActionResult>RegisterUser(UserRegisterRequestModel item)
        {
            AppUser appUser = new()
            {
                UserName = item.UserName,
                Email = item.Email,
                PasswordHash = item.Password
            };
            bool result = await _appUserManger.CreateUser(appUser);
            if (result)
            {
                return Ok("Adding user successful");
            }
            return BadRequest("There was a problem adding user");
        }
    }
}
