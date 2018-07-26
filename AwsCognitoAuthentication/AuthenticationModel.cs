
namespace AwsCognitoAuthentication
{
    public class AuthenticationModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PoolId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RegionEndpoint { get; set; }
    }
}
