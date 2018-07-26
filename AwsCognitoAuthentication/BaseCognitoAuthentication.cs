using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.Runtime;
using System;
using System.Threading.Tasks;

namespace AwsCognitoAuthentication
{
    public class BaseCognitoAuthentication
    {
        protected int ExpiresIn { get; set; }
        protected async Task<string> GetAccessToken(AuthenticationModel model)
        {
            string responseToken = String.Empty;

            try
            {
                AmazonCognitoIdentityProviderClient IdentityClientProvider = new AmazonCognitoIdentityProviderClient(
                new AnonymousAWSCredentials(), RegionEndpoint.GetBySystemName(model.RegionEndpoint));
                CognitoUserPool UserPool = new CognitoUserPool(model.PoolId, model.ClientId, IdentityClientProvider);
                CognitoUser user = new CognitoUser(model.Username, model.ClientId, UserPool, IdentityClientProvider);
                var response = await user.StartWithSrpAuthAsync(new InitiateSrpAuthRequest { Password = model.Password }).ConfigureAwait(false);

                if (response.AuthenticationResult != null)
                {
                    responseToken = response.AuthenticationResult.AccessToken;
                    ExpiresIn = response.AuthenticationResult.ExpiresIn - 300;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return responseToken;
        }

    }
}
