using DataLayer.Context;
using DataLayer.Entities;
using EarlyWarningSystem.Common;
using EarlyWarningSystem.NavigationHelper;
using EarlyWarningSystem.View;
using Prism.Commands;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EarlyWarningSystem.ViewModel
{
    public class LoginViewModel : Page
    {
        public EwscdContext DbContext { get; set; }

        #region Свойства зависимости

        public string Login
        {
            get { return (string)GetValue(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }
        public static readonly DependencyProperty LoginProperty =
            DependencyProperty.Register("Login", typeof(string), typeof(LoginViewModel), new PropertyMetadata(null));



        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(LoginViewModel), new PropertyMetadata(null));



        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(LoginViewModel), new PropertyMetadata(null));



        public DelegateCommand LoginCommand
        {
            get { return (DelegateCommand)GetValue(LoginCommandProperty); }
            set { SetValue(LoginCommandProperty, value); }
        }

        public static readonly DependencyProperty LoginCommandProperty =
            DependencyProperty.Register("LoginCommand", typeof(DelegateCommand), typeof(LoginViewModel), new PropertyMetadata(null));



        public DelegateCommand RegistrationCommand
        {
            get { return (DelegateCommand)GetValue(RegistrationCommandProperty); }
            set { SetValue(RegistrationCommandProperty, value); }
        }

        public static readonly DependencyProperty RegistrationCommandProperty =
            DependencyProperty.Register("RegistrationCommand", typeof(DelegateCommand), typeof(LoginViewModel), new PropertyMetadata(null));

        #endregion

        #region Конструкторы

        public LoginViewModel()
        {
            DbContext = new EwscdContext();
            LoginCommand = new DelegateCommand(LogIn);
            RegistrationCommand = new DelegateCommand(Registration);
        }

        #endregion

        #region Методы 

        private void LogIn()
        {
            if (!String.IsNullOrEmpty(Login) && !String.IsNullOrEmpty(Password))
            {
                User user = DbContext.Users.SingleOrDefault(x => x.Login == Login);

                if (user != null && Security.Verify(Password, user.PasswordHash))
                {
                    //Properties.Settings.Default.UserName = user.Login;
                    //if (user.UserRoles.Any(x => x.Role.Is(Role.Administrator)))
                    //{
                    //    Navigation.NavigateTo(new AdministratorMainPage());
                    //}
                    //else if (user.UserRoles.Any(x => x.Role.Is(Role.Сurator)) ||
                    //    user.UserRoles.Any(x => x.Role.Is(Role.Teacher)))
                    //{
                    //    Navigation.NavigateTo(new CuratorView());
                    //}
                    //else
                    //{
                    //    Navigation.NavigateTo(new DoctorView());
                    //}
                }
                else
                {
                    ErrorMessage = "Не верный логин или пароль";
                }
            }
            else
            {
                ErrorMessage = "Для авторизации необходимо ввести логин и пароль";
            }
        }


        private void Registration()
        {
            Navigation.NavigateTo(new RegistrationView());
        }
        #endregion
    }
}
