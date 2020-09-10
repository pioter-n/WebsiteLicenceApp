using LicenceApp.Model;
using LicenceApp.ViewModel;
using LicenceApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LicenceApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      //  MyDbContext _dbContext;
        public MainWindow()
        {
            InitializeComponent();
            this.ViewModel = new MainViewModel();
         
        }

        public MainViewModel ViewModel
        {
            get
            {
                return this.DataContext as MainViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
        /* private async void BtnOK_Click(object sender, RoutedEventArgs e)
         {
             MyToken myToken = new MyToken();
             if (String.IsNullOrEmpty(TBUser.Text) || String.IsNullOrWhiteSpace(TBUser.Text))
             {
                 LbPassWrong.Content = "Insert password or username!";
                 return;
             }
             else if (InternetConnection.Connection)
             {
                 if (!await myToken.RequestPasswordToken(TBUser.Text, TBPass.Password))
                 {
                     LbPassWrong.Content = "Invalid password or username!";
                     return;
                 }
                 else
                 {
                     if (_dbContext.Users.Count(t => t.Name == TBUser.Text) == 0)
                     {
                         User User = new User();
                         User.Name = TBUser.Text;
                         User.Password = TBPass.Password;
                         _dbContext.Add(User);
                         _dbContext.SaveChanges();
                     }
                 }
             }
             else
             {
                 User User = new User();
                 //User.Name = TBUser.Text;
                 //User.Password = TBPass.Password;
                 if(_dbContext.Users.Count(t => t.Name == TBUser.Text)!=0)
                     User= _dbContext.Users.Where(t => t.Name == TBUser.Text).FirstOrDefault();
                 else
                 {
                     LbPassWrong.Content = "Invalid password or username!";
                     return;

                 }
                 //_dbContext.SaveChanges();

                 return;
             }

            // MainWindow Main = new MainWindow();
            // Main.Show();
            // this.Close();
         }

         private void BtnCancel_Click(object sender, RoutedEventArgs e)
         {
             this.Close();
         }*/
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

       /* private void LoginWindow1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                BtnOK_Click(null, null);
            else if ((e.Key == Key.Escape))
                BtnCancel_Click(null, null);
        }*/
    }
}
