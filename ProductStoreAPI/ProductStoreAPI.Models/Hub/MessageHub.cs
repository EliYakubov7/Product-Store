using Microsoft.AspNetCore.SignalR;
using ProductStoreAPI.Models.Auth;
using System;
using System.Threading.Tasks;

namespace ProductStoreAPI.Models.Hub
{
	public sealed class MessageHub : Hub<IMessageHubClient>
	{
		public async Task SendAuthStatusToUsers(AuthStatusHub authStatusHub)
		{
			try
			{
				await Clients.All.SendAuthStatusToUsers(authStatusHub);
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(
					$"Error while trying to SendAuthStatusToUsers: {ex.Message}");

				throw;
			}
		}
	}
}
