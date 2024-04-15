using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDto = ProductStoreAPI.Models.Business.User;

namespace ProductStoreAPI.Repository.Repositories.User
{
	public sealed class UserRepository(
		ApplicationDbContext context)
		: IUserRepository
	{
		public async Task<IList<UserDto.User>> GetAllUsersAsync(
			int pageNumber,
			int pageSize)
		{
			if (pageNumber < 1)
				throw new ArgumentException("Page number must be greater than 0.", nameof(pageNumber));

			if (pageSize < 1)
				throw new ArgumentException("Page size must be greater than 0.", nameof(pageSize));

			try
			{
				return await context.Users
					.Skip((pageNumber - 1) * pageSize)
					.Take(pageSize)
					.ToListAsync();
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(
					$"Error while trying to GetAllUsersAsync: {ex.Message}");

				throw;
			}
		}

		public async Task<UserDto.User> GetUserByIdAsync(
			string userId)
		{
			UserDto.User user = null;

			try
			{
				user = await context.Users.FindAsync(
					userId);
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(
					$"Error while trying to GetUserAsync: {ex.Message}");

				throw;
			}

			return user;
		}

		public async Task UpdateUserAsync(
			UserDto.User user)
		{
			try
			{
				user.NormalizedEmail = user.Email.ToUpper().Trim();
				user.NormalizedUserName = user.UserName.ToUpper().Trim();

				context.Users.Update(user);

				await context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(
					$"Error while trying to UpdateUserAsync: {ex.Message}");

				throw;
			}
		}

		public async Task<bool> DeleteUserAsync(
			string userId,
			string currentUserEmail)
		{
			bool isDeleted = false;

			try
			{
				var currentUser = await context.Users
					.FirstOrDefaultAsync(x => x.Email == currentUserEmail);

				var user = await context.Users
					.Where(x => x.Id != currentUser.Id)
					.FirstOrDefaultAsync(y => y.Id == userId);

				if (user != null)
				{
					context.Users.Remove(user);

					await context.SaveChangesAsync();

					isDeleted = true;
				}
				else
				{
					await Console.Out.WriteLineAsync(
						$"User with {nameof(userId)}: {userId}, not found!");
				}
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(
					$"Error while trying to DeleteUserAsync with {nameof(userId)}: {userId}, {ex.Message}");

				throw;
			}

			return isDeleted;
		}
	}
}
