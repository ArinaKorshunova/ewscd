using System.Windows;
using System.Windows.Navigation;

namespace EarlyWarningSystem.NavigationHelper
{
    public static class Navigation
    {
        public static void NavigateTo(object navigationTarget)
        {
            NavigationWindow win = (NavigationWindow)Application.Current.MainWindow;
            win.Content = navigationTarget;
            win.Show();
        }

        public static void NavigateTo(object navigationTarget, object navigationContext)
        {
            NavigationWindow win = (NavigationWindow)Application.Current.MainWindow;
            win.DataContext = navigationContext;
            win.Content = navigationTarget;
            win.Show();
        }
    }
}
