using ProductStoreAPI.Models.Auth;
using System.Threading.Tasks;

namespace ProductStoreAPI.Repository.Repositories.Auth
{
    public interface IAuthRepository
    {
        /// <summary>
        /// Registers a new user with a specific role.
        /// </summary>
        /// <param name="model">The registration model containing user details.</param>
        /// <param name="role">The role to assign to the user.</param>
        /// <returns>A tuple indicating success or failure, and a message.</returns>
        Task<(bool IsSuccess, string Message)> DoRegistrationAsync(
            RegistrationModel model,
            string role);

        /// <summary>
        /// Authenticates a user and generates a JWT token if successful.
        /// </summary>
        /// <param name="model">The login model containing login credentials.</param>
        /// <returns>A tuple indicating success or failure, and a message or token.</returns>
        Task<TokenResponse> DoLoginAsync(
            LoginModel model);

        /// <summary>
        /// Initiates a user log out.
        /// </summary>
        /// /// <param name="userName">The user name of the current user.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DoLogoutAsync(
            string userName);
    }
}