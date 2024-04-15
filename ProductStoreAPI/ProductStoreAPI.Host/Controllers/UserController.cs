using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductStoreAPI.Models.Business.User;
using ProductStoreAPI.Repository.Repositories.User;
using System.Threading.Tasks;

namespace ProductStoreAPI.Host.Controllers
{
	[Authorize(Roles = "SiteAdministrator")]
	public class UserController(
		IUserRepository userRepository)
		: ApiBaseController
	{
		[HttpGet("All")]
		[AllowAnonymous]
		public async Task<IActionResult> GetAll(
			[FromQuery] int pageNumber = 1,
			[FromQuery] int pageSize = 2)
		{
			var users = await userRepository.GetAllUsersAsync(
				pageNumber, pageSize);

			return Ok(users);
		}

		[HttpGet("{userId}")]
		public async Task<IActionResult> GetById(
			string userId)
		{
			var user = await userRepository.GetUserByIdAsync(
				userId);

			if (user == null)
			{
				return NotFound();
			}

			return Ok(user);
		}

		[HttpPut("Update")]
		public async Task<IActionResult> Put(
			[FromBody] User userObj)
		{
			await userRepository.UpdateUserAsync(
				userObj);

			return Ok(true);
		}

		[HttpDelete("{userId}")]
		public async Task<IActionResult> Delete(
			[FromRoute] string userId)
		{
			var isDeleted = await userRepository.DeleteUserAsync(
				userId,
				User.Identity.Name);

			if (!isDeleted)
			{
				return BadRequest();
			}

			return Ok(true);
		}
	}
}