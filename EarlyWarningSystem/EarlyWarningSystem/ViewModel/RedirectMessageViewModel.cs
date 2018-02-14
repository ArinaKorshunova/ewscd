using EarlyWarningSystem.NavigationHelper;
using Prism.Commands;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EarlyWarningSystem.ViewModel
{
    public class RedirectMessageViewModel : Page
    {
        public int TimeShow { get; set; }
        public object RedirectObject { get; set; }

        #region Свойства зависимости

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(RedirectMessageViewModel), new PropertyMetadata(null));


        public DelegateCommand PageLoadedCommand
        {
            get { return (DelegateCommand)GetValue(PageLoadedCommandProperty); }
            set { SetValue(PageLoadedCommandProperty, value); }
        }
        public static readonly DependencyProperty PageLoadedCommandProperty =
            DependencyProperty.Register("PageLoadedCommand", typeof(DelegateCommand), typeof(RedirectMessageViewModel), new PropertyMetadata(null));


        #endregion

        #region Конструкторы

        public RedirectMessageViewModel(string message, int timeShow, object redirectObject)
        {
            Message = message;
            TimeShow = timeShow;
            RedirectObject = redirectObject;
            PageLoadedCommand = new DelegateCommand(PageLoaded);
        }

        #endregion

        #region Методы

        private async void PageLoaded()
        {
            await Task.Delay(TimeShow);

            Navigation.NavigateTo(RedirectObject);
        }

        #endregion

    }
}
