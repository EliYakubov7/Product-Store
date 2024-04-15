using System.ComponentModel.DataAnnotations;

namespace ProductStoreAPI.Models.Auth
{
	public sealed class RegistrationModel
	{
		[Required(ErrorMessage = "FullName is required")]
		public string FullName { get; set; }

		[EmailAddress]
		[Required(ErrorMessage = "Email is required")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password is required")]
		public string Password { get; set; }
	}
}
