using System.Collections.Generic;
using System.Threading.Tasks;
using UserDto = ProductStoreAPI.Models.Business.User;

namespace ProductStoreAPI.Repository.Repositories.User
{
	public interface IUserRepository
	{
		/// <summary>
		/// Retrieves a paginated list of users.
		/// </summary>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The number of items per page.</param>
		/// <returns>A list of users for the specified page.</returns>
		Task<IList<UserDto.User>> GetAllUsersAsync(
			int pageNumber,
			int pageSize);

		/// <summary>
		/// Retrieves a single user by their ID.
		/// </summary>
		/// <param name="userId">The ID of the user to retrieve.</param>
		/// <returns>The user if found; otherwise, null.</returns>
		Task<UserDto.User> GetUserByIdAsync(
			string userId);

		/// <summary>
		/// Updates an existing user in the database.
		/// </summary>
		/// <param name="user">The user object to update.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		Task UpdateUserAsync(
			UserDto.User user);

		/// <summary>
		/// Deletes a user by their ID.
		/// </summary>
		/// <param name="userId">The ID of the user to delete.</param>
		/// <param name="currentUserEmail">The email of the user taken from context.</param>
		/// <returns>True if the user is successfully deleted; otherwise, false.</returns>
		Task<bool> DeleteUserAsync(
			string userId,
			string currentUserEmail);
	}
}
