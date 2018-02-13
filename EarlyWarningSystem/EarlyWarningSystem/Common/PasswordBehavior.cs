using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace EarlyWarningSystem.Common
{
    public class PasswordBehavior : Behavior<PasswordBox>
    {
        public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.Register("Password", typeof(string), typeof(PasswordBehavior), new PropertyMetadata(default(string)));
        public static readonly DependencyProperty HashPasswordProperty =
        DependencyProperty.Register("HashPassword", typeof(string), typeof(PasswordBehavior), new PropertyMetadata(default(string)));

        private bool _skipUpdate;

        public string HashPassword
        {
            get { return (string)GetValue(HashPasswordProperty); }
            set { SetValue(HashPasswordProperty, value); }
        }

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        protected override void OnAttached()
        {
            AssociatedObject.PasswordChanged += PasswordBox_PasswordChanged;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.PasswordChanged -= PasswordBox_PasswordChanged;
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property == PasswordProperty)
            {
                if (!_skipUpdate)
                {
                    _skipUpdate = true;
                    AssociatedObject.Password = e.NewValue as string;
                    _skipUpdate = false;
                }
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _skipUpdate = true;
            Password = AssociatedObject.Password;
            HashPassword = Security.HashPassword(AssociatedObject.Password);
            _skipUpdate = false;
        }
    }
}
