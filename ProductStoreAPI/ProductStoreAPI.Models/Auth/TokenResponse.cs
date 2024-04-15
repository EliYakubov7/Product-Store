namespace ProductStoreAPI.Models.Auth
{
    public sealed class TokenResponse(
        bool isSuccess,
        string message,
        string token)
    {
        public bool IsSuccess { get; set; } = isSuccess;

        public string Message { get; set; } = message;

        public string Token { get; private set; } = token;
    }
}