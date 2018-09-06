namespace Store.Common.Google
{
    public class GoogleCloudAuthenticationSettings
    {
        public string Type { get; set; }
        public string ProjectId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ClientEmail { get; set; }
        public string PrivateKey { get; set; }
        public string RefreshToken { get; set; }
    }
}