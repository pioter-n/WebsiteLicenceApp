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
        IMyToken _token;

        public LoginWindow()
        {

            InitializeComponent();
        }
            public LoginWindow(IMyToken token)
        {
            
            InitializeComponent();
            _token = token;
        }
        private async void BtnOK_Click(object sender, RoutedEventArgs e)
        {

            _token = new MyToken();
            if (String.IsNullOrEmpty(TBUser.Text) || String.IsNullOrWhiteSpace(TBUser.Text))
            {
                this.Close();
            }
            else if (InternetConnection.Connection)
            {
                if (!await _token.RequestPasswordToken(TBUser.Text, TBPass.Password))
                {
                    LbPassWrong.Content = "Invalid password or username!";
                    return;
                }
            }
            else
            {
                return;
            }

            MainWindow Main = new MainWindow();
            Main.Show();
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       /* private async Task<bool> Call()
        {
            
            

            client.SetBearerToken(requestPasswordToken.AccessToken);
            var res = await client.GetAsync($"{url}/api/Licence");

            if (!res.IsSuccessStatusCode)
            {
                Console.WriteLine(res.StatusCode);
                return false;
            }

            var content = await res.Content.ReadAsStringAsync();
            Console.WriteLine(content);


            return true;

        }*/

        private void LoginWindow1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                BtnOK_Click(null, null);
            else if ((e.Key == Key.Escape))
                BtnCancel_Click(null, null);
        }
    }
}
