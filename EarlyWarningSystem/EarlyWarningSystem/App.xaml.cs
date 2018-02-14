using EarlyWarningSystem.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace EarlyWarningSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private NavigationWindow navigationWindow;
        
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            navigationWindow = new NavigationWindow();
            navigationWindow.Height = 850;
            navigationWindow.Width = 1200;
            var page = new LoginView();
            navigationWindow.Navigate(page);
            navigationWindow.Show();
        }
    }
}
