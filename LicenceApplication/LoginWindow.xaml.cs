using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LicenceApplication
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        private async void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TBUser.Text) || String.IsNullOrWhiteSpace(TBUser.Text))
            {

                this.Close();
            }
            else
                await Call();

            MainWindow Main = new MainWindow();
            Main.Show();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private async Task Call()
        {
            const string clientId = "Authentication.Agent";
            const string url = "https://localhost:44370";
            var client = new HttpClient();
            var requestPasswordToken = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = $"{url}/connect/token",

                ClientId = clientId,
                Scope = "api openid profile Authentication.WebAPI",

                UserName = TBUser.Text,
                Password = TBPass.Password
            });
            if (requestPasswordToken.IsError)
            {
                Console.WriteLine(requestPasswordToken.HttpStatusCode);
                throw new InvalidOperationException("Invalid password!");
            }
            Console.WriteLine($"Logged in! {requestPasswordToken.Raw}");

            Console.WriteLine("Getting endpoints!");

            var documentResponse = await client.GetDiscoveryDocumentAsync(url);

            if (documentResponse.IsError)
            {
                Console.WriteLine(requestPasswordToken.HttpStatusCode);
                throw new InvalidOperationException("Unable to get endpoints!");
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
                throw new InvalidOperationException("Unable to get userinfo!");
            }

            Console.WriteLine(userInfoResponse.HttpStatusCode);
            Console.WriteLine($"Hello Mr {userInfoResponse.Claims.Single(x => x.Type == "name").Value}");

            client.SetBearerToken(requestPasswordToken.AccessToken);
            var res = await client.GetAsync($"{url}/api/LicenceModels");

            if (!res.IsSuccessStatusCode)
            {
                Console.WriteLine(res.StatusCode);
                throw new InvalidOperationException("Unable to get resources!");
            }

            var content = await res.Content.ReadAsStringAsync();
            Console.WriteLine(content);

            Console.WriteLine("Trying to get resource as unauthenticated user.");
            client.SetBearerToken(string.Empty);

            res = await client.GetAsync($"{url}/api/LicenceModels");
            Console.WriteLine(res.StatusCode);
             content = await res.Content.ReadAsStringAsync();
            Console.WriteLine(content);


        }
    }
}
