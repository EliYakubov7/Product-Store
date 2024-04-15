using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductStoreAPI.Models.Auth;
using ProductStoreAPI.Models.Hub;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserDto = ProductStoreAPI.Models.Business.User;

namespace ProductStoreAPI.Repository.Repositories.Auth
{
    public sealed class AuthRepository(
        UserManager<UserDto.User> userManager,
        RoleManager<IdentityRole> roleManager,
        SignInManager<UserDto.User> signInManager,
        IConfiguration configuration,
        IHubContext<MessageHub, IMessageHubClient> messageHub)
        : IAuthRepository
    {
        public async Task<(bool IsSuccess, string Message)> DoRegistrationAsync(
            RegistrationModel model,
            string role)
        {
            try
            {
                var userExists = await userManager.FindByEmailAsync(
                    model.Email);

                if (userExists != null)
                {
                    return (false, "Email already exists.");
                }

                UserDto.User user = new()
                {
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Name = model.FullName,
                    UserName = model.Email
                };

                var createUserResult = await userManager.CreateAsync(
                    user, model.Password);

                if (!createUserResult.Succeeded)
                {
                    return (false, "User registration failed! Please check user details and try again.");
                }

                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(
                        new IdentityRole(role));
                }

                if (await roleManager.RoleExistsAsync(UserRoles.Client))
                {
                    await userManager.AddToRoleAsync(user, role);
                }

                return (true, "User created successfully!");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(
                    $"Error while trying to DoRegistrationAsync: {ex.Message}");

                return new(false, "Something went wrong, try again.");
            }
        }

        public async Task<TokenResponse> DoLoginAsync(
            LoginModel model)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(
                    model.Email);

                if (user == null)
                {
                    return new(false, "User does not exist.", string.Empty);
                }

                if (!await userManager.CheckPasswordAsync(user, model.Password))
                {
                    return new(false, "Email/Password is not correct, please try again.", null);
                }

                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, user.Id),
                    new(ClaimTypes.Name, user.UserName),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GenerateJwtToken(authClaims);

                await messageHub.Clients.All.SendAuthStatusToUsers(new()
                {
                    Name = user.Name,
                    IsAuthenticated = true
                });

                return new(true, "Successfully logged in!", token);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(
                    $"Error while trying to DoLoginAsync: {ex.Message}");

                return new(false, "Something went wrong, try again.", null);
            }
        }

        public async Task DoLogoutAsync(
            string userName)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(
                    userName);

                await signInManager.SignOutAsync();

                if (user != null)
                {
                    await messageHub.Clients.All.SendAuthStatusToUsers(new()
                    {
                        Name = user.Name,
                        IsAuthenticated = false
                    });
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(
                    $"Error while trying to DoSignOutAsync: {ex.Message}");

                throw;
            }
        }

        private string GenerateJwtToken(
            IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = configuration["JWT:ValidIssuer"],
                Audience = configuration["JWT:ValidAudience"],
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}