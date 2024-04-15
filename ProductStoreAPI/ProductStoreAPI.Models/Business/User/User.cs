using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProductStoreAPI.Models.Business.User
{
	public sealed class User : IdentityUser
	{
		[MaxLength(30)]
		public string Name { get; set; }

    }
}