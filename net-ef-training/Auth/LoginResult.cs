namespace net_ef_training.Auth
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public string Token { get; set; }
    }
}