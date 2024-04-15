using ProductStoreAPI.Models.Auth;
using System.Threading.Tasks;

namespace ProductStoreAPI.Models.Hub
{
	public interface IMessageHubClient
	{
		Task SendAuthStatusToUsers(AuthStatusHub authStatusHub);
	}
}
