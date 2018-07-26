
namespace AwsCognitoAuthentication
{
    public sealed class AWSCognitoAuthentication : BaseCognitoAuthentication
    {
        private string oneTimetoken;
        //Call this methid to initialise the authentication and set token
        public AWSCognitoAuthentication(AuthenticationModel model)
        {
            oneTimetoken = base.GetAccessToken(model).GetAwaiter().GetResult(); 
        }
        //Call this method to return the token
        public string GetToken()
        {
            return oneTimetoken;
        }
    }
}
