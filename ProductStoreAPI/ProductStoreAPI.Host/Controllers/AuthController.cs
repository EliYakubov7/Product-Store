using Microsoft.AspNetCore.Mvc;
using ProductStoreAPI.Models.Auth;
using ProductStoreAPI.Repository.Repositories.Auth;
using System.Threading.Tasks;

namespace ProductStoreAPI.Host.Controllers
{
    public class AuthController(
        IAuthRepository authRepository)
        : ApiBaseController
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tokenResponse = await authRepository.DoLoginAsync(
                model);

            if (!tokenResponse.IsSuccess)
            {
                return BadRequest(tokenResponse.Message);
            }

            return Ok(tokenResponse);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(
            [FromBody] RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var (isSuccess, message) = await authRepository.DoRegistrationAsync(
                model, UserRoles.Client);

            if (!isSuccess)
            {
                return BadRequest(message);
            }

            var tokenResponse = await authRepository.DoLoginAsync(
                new LoginModel() { Email = model.Email, Password = model.Password });

            if (!tokenResponse.IsSuccess)
            {
                return BadRequest(tokenResponse.Message);
            }

            return Ok(tokenResponse);
        }

        [HttpPost("SignOut")]
        public async Task<IActionResult> Logout()
        {
            await authRepository.DoLogoutAsync(
                User.Identity.Name);

            return Ok(true);
        }
    }
}