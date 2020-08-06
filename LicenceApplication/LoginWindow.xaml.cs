using System;
using System.Collections.Generic;
using System.Net.Http;
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
        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            /* if (!String.IsNullOrEmpty(TBUser.Text) && !String.IsNullOrWhiteSpace(TBUser.Text))
             {
                 MainWindow Main = new MainWindow();
                 Main.Show();
                 this.Close();
             }*/
            _ = PostCallAPI();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public static async Task<object> PostCallAPI()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:44370/connect/token");
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);

            return null;
        }
    }
}
