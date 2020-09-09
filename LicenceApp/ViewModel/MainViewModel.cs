using GalaSoft.MvvmLight.Command;
using LicenceApp.Command;
using LicenceApp.Model;
using LicenceApplication;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace LicenceApp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
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
                    OnPropertyChanged("isIncorrect");
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
                OnPropertyChanged("UserName");
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public ICommand LoginCommand
        {
            get { return new RelayCommand(async () => await LoginAsync()); }
        }

        public async System.Threading.Tasks.Task LoginAsync()
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
                    if (_dbContext.Users.Count(t => t.Name == UserName) == 0)
                    {
                        User User = new User();
                        User.Name = UserName;
                        User.Password = Password;
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
                if (_dbContext.Users.Count(t => t.Name == UserName) != 0)
                    User = _dbContext.Users.Where(t => t.Name == UserName).FirstOrDefault();
                else
                {
                    isIncorrect = true;
                    return;

                }
                

               
            }
        }

       /* public ICommand CancelCommand
        {
            get { return new RelayCommand(() => Cancel(object-)); }
        }

        public void Cancel()
        {
            System.Windows.Window win = 
        }*/

        #region INotifyPropertyChanged Methods

        public void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, args);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
