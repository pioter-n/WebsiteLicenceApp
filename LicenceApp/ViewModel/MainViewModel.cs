using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IdentityModel.Client;
using LicenceApp.Model;
using LicenceApplication;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Input;

namespace LicenceApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isIncorrect;
        private MyDbContext _dbContext;
        public MainViewModel()
        {
            _dbContext = new MyDbContext();
        }
        public bool isIncorrect
        {
            get { return _isIncorrect; }
            set
            {
                if (value != _isIncorrect)
                {
                    _isIncorrect = value;
                    RaisePropertyChanged(nameof(isIncorrect));
                }
            }
        }
        private string _username;
        public string UserName
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged(nameof(UserName));
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand
        {
            get { return new RelayCommand(async () => await LoginAsync()); }
        }

        private async System.Threading.Tasks.Task LoginAsync()
        {
            
            if (String.IsNullOrEmpty(UserName) || String.IsNullOrEmpty(Password))
            {
                isIncorrect = true;
                return;
            }
            else if (InternetConnection.Connection)
            {
                MyToken myToken = new MyToken();
                if (!await myToken.RequestPasswordToken(UserName, Password))
                {

                    isIncorrect = true;
                    return;
                }
                else
                {
                    HttpClient client = new HttpClient();
                        client.SetBearerToken(MyToken.requestPasswordToken.AccessToken);
                    var res = await client.GetAsync("https://localhost:44370/api/UserLicence");
                    if (_dbContext.Users.Count(t => t.Name == UserName) == 0)
                    {
                        byte[] PasByte = MyHash.GenerateSaltedHash(Encoding.Unicode.GetBytes(Password));
                        User User = new User();
                        User.Name = UserName;
                        User.Password = PasByte;
                        _dbContext.Add(User);
                        _dbContext.SaveChanges();
                    }
                }
            }
            else
            {
                User User = new User();
   
                if (_dbContext.Users.Count(t => t.Name == UserName) != 0)
                    User = _dbContext.Users.Where(t => t.Name == UserName).FirstOrDefault();
                else
                {
                    isIncorrect = true;
                    return;

                }
            }
        }
    }
}
