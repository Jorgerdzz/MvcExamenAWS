using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Newtonsoft.Json.Linq;

namespace MvcExamenAWS.Helpers
{
    public static class HelperSecretManager
    {
        public static async Task<string> GetValueSecretAsync()
        {
            var region = "us-east-2";
            var secretName = "secretozapatillas";

            using (var client = new AmazonSecretsManagerClient(Amazon.RegionEndpoint.GetBySystemName(region)))
            {
                var request = new GetSecretValueRequest
                {
                    SecretId = secretName,
                    VersionStage = "AWSCURRENT"
                };

                GetSecretValueResponse response;
                try
                {
                    response = await client.GetSecretValueAsync(request);
                }
                catch (Exception)
                {
                    throw;
                }

                string secret = response.SecretString;
                JObject json = JObject.Parse(secret);
                return json["connectionMySql"].ToString();
            }
        }
    }
}
