using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Unity;

namespace LicenceApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public System.IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IMyToken, MyToken>();

            var loginwindow = container.Resolve<LoginWindow>();
            //var window = new MainWindow { DataContext = loginwindow };
            loginwindow.Show();
        }
      
    }
}
