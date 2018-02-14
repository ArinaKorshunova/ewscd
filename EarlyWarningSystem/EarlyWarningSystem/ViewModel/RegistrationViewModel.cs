using DataLayer.Context;
using DataLayer.Entities;
using EarlyWarningSystem.Common;
using EarlyWarningSystem.NavigationHelper;
using EarlyWarningSystem.View;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EarlyWarningSystem.ViewModel
{
    public class RegistrationViewModel : Page
    {
        public EwscdContext DbContext { get; set; }
        #region Свойства зависимости

        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(RegistrationViewModel), new PropertyMetadata(null));


        public List<string> RoleList
        {
            get { return (List<string>)GetValue(RoleListProperty); }
            set { SetValue(RoleListProperty, value); }
        }
        public static readonly DependencyProperty RoleListProperty =
            DependencyProperty.Register("RoleList", typeof(List<string>), typeof(RegistrationViewModel), new PropertyMetadata(null));


        public Employee Employee
        {
            get { return (Employee)GetValue(EmployeeProperty); }
            set { SetValue(EmployeeProperty, value); }
        }
        public static readonly DependencyProperty EmployeeProperty =
            DependencyProperty.Register("Employee", typeof(Employee), typeof(RegistrationViewModel), new PropertyMetadata(null));


        public string Login
        {
            get { return (string)GetValue(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }
        public static readonly DependencyProperty LoginProperty =
            DependencyProperty.Register("Login", typeof(string), typeof(RegistrationViewModel), new PropertyMetadata(null));


        public string PasswordFirst
        {
            get { return (string)GetValue(PasswordFirstProperty); }
            set { SetValue(PasswordFirstProperty, value); }
        }
        public static readonly DependencyProperty PasswordFirstProperty =
            DependencyProperty.Register("PasswordFirst", typeof(string), typeof(RegistrationViewModel), new PropertyMetadata(null));


        public string PasswordSecond
        {
            get { return (string)GetValue(PasswordSecondProperty); }
            set { SetValue(PasswordSecondProperty, value); }
        }
        public static readonly DependencyProperty PasswordSecondProperty =
            DependencyProperty.Register("PasswordSecond", typeof(string), typeof(RegistrationViewModel), new PropertyMetadata(null));


        public DelegateCommand OkCommand
        {
            get { return (DelegateCommand)GetValue(OkCommandProperty); }
            set { SetValue(OkCommandProperty, value); }
        }
        public static readonly DependencyProperty OkCommandProperty =
            DependencyProperty.Register("OkCommand", typeof(DelegateCommand), typeof(RegistrationViewModel), new PropertyMetadata(null));


        public DelegateCommand CancelCommand
        {
            get { return (DelegateCommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }
        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register("CancelCommand", typeof(DelegateCommand), typeof(RegistrationViewModel), new PropertyMetadata(null));


        #endregion

        #region Конструкторы

        public RegistrationViewModel()
        {
            DbContext = new EwscdContext();
            RoleList = new List<string> { "Врач", "Крутор" };
            Employee = new Employee();
            OkCommand = new DelegateCommand(Register);
            CancelCommand = new DelegateCommand(Cancel);
        }

        #endregion

        #region Методы

        private void Register()
        {
            if (!String.IsNullOrEmpty(Employee.FIO) && !String.IsNullOrEmpty(Employee.Role) &&
                !String.IsNullOrEmpty(Employee.Specialization) && !String.IsNullOrEmpty(Employee.City) &&
                !String.IsNullOrEmpty(Login) && !String.IsNullOrEmpty(PasswordFirst) &&
                !String.IsNullOrEmpty(PasswordSecond))
            {
                if (!Security.Verify(PasswordSecond, PasswordFirst))
                {
                    ErrorMessage = "Пароли не совпадают!";
                    return;
                }

                if (DbContext.Users.Any(x => x.Login == Login))
                {
                    ErrorMessage = "Пользователь с таким логином уже существует";
                    return;
                }
                try
                {
                    using (var dbContextTransaction = DbContext.Database.BeginTransaction())
                    {
                        User newUser = new User
                        {
                            Login = Login,
                            PasswordHash = PasswordFirst,
                            CreateDate = DateTime.Now
                        };
                        DbContext.Users.Add(newUser);
                        DbContext.DetectAndSaveChanges();
                        User currentUser = DbContext.Users.First(x => x.Login == Login);
                        
                        Employee.UserId = currentUser.Id;
                        Employee.CreateDate = DateTime.Now;
                        DbContext.Employees.Add(Employee);
                        DbContext.DetectAndSaveChanges();

                        dbContextTransaction.Commit();
                    }

                    Navigation.NavigateTo(new RedirectMessage(), new RedirectMessageViewModel("Регистрация прошла успешно", 1000,
                        new LoginView()));
                }
                catch (Exception ex)
                {
                    ErrorMessage = string.Format("При выполнении операции возникла следующая ошибка: {0}", ex.Message);
                    return;
                }

            }
            else
            {
                ErrorMessage = "Заполнены не все обязательные поля!";
            }
        }

        private void Cancel()
        {
            Navigation.NavigateTo(new LoginView());
        }
        #endregion

    }
}
