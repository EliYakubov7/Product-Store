namespace ProductStoreAPI.Models.Auth
{
	public sealed class AuthStatusHub
	{
		public string Name { get; init; }

		public bool IsAuthenticated { get; init; }
	}
}
