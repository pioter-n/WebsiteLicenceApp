using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LicenceApp
{
     class MyToken 
    {
        private TokenResponse requestPasswordToken;
        private HttpClient client;
        const string clientId = "Authentication.Agent";
        const string url = "https://localhost:44370";
        static string token;
        public string Token
        {
            get { return token; }
            set => token = requestPasswordToken==null?"" : requestPasswordToken.AccessToken;
        }
         public async Task<bool> RequestPasswordToken(string User, string Pass)
        {

            client = new HttpClient();
            requestPasswordToken = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = $"{url}/connect/token",
                ClientId = clientId,
                UserName = User,
                Password = Pass
            });
            if (requestPasswordToken.IsError)
            {

                return false;
            }
            Token = requestPasswordToken.AccessToken;
            return true;
        }
       /* static public async Task<bool> GetUserInfo()
        {
            Console.WriteLine($"Logged in! {requestPasswordToken.Raw}");

            Console.WriteLine("Getting endpoints!");

            var documentResponse = await client.GetDiscoveryDocumentAsync(url);

            if (documentResponse.IsError)
            {
                Console.WriteLine(requestPasswordToken.HttpStatusCode);
                return false;
            }

            Console.WriteLine("Getting user!");

            var userInfoResponse = await client.GetUserInfoAsync(new UserInfoRequest
            {
                ClientId = clientId,

                Address = documentResponse.UserInfoEndpoint,
                Token = requestPasswordToken.AccessToken
            });

            if (userInfoResponse.IsError)
            {
                Console.WriteLine(requestPasswordToken.HttpStatusCode);
                return false;
            }

            Console.WriteLine(userInfoResponse.HttpStatusCode);
            Console.WriteLine($"Hello Mr {userInfoResponse.Claims.Single(x => x.Type == "name").Value}");
            return true;
        }*/
    }
}
