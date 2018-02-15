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
    public class AddPatientViewModel : Page
    {
        public EwscdContext DbContext { get; set; }
        #region Свойства зависимости

        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(AddPatientViewModel), new PropertyMetadata(null));


        public Patient Patient
        {
            get { return (Patient)GetValue(PatientProperty); }
            set { SetValue(PatientProperty, value); }
        }
        public static readonly DependencyProperty PatientProperty =
            DependencyProperty.Register("Patient", typeof(Patient), typeof(AddPatientViewModel), new PropertyMetadata(null));

        
        public DelegateCommand OkCommand
        {
            get { return (DelegateCommand)GetValue(OkCommandProperty); }
            set { SetValue(OkCommandProperty, value); }
        }
        public static readonly DependencyProperty OkCommandProperty =
            DependencyProperty.Register("OkCommand", typeof(DelegateCommand), typeof(AddPatientViewModel), new PropertyMetadata(null));


        public DelegateCommand CancelCommand
        {
            get { return (DelegateCommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }
        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register("CancelCommand", typeof(DelegateCommand), typeof(AddPatientViewModel), new PropertyMetadata(null));


        #endregion

        #region Конструкторы

        public AddPatientViewModel()
        {
            DbContext = new EwscdContext();
            Patient = new Patient();
            OkCommand = new DelegateCommand(Register);
            CancelCommand = new DelegateCommand(Cancel);
        }

        #endregion

        #region Методы

        private void Register()
        {
            if (!String.IsNullOrEmpty(Patient.FIO) && Patient.BirthDate != DateTime.MinValue &&
                !String.IsNullOrEmpty(Patient.Disease) && !String.IsNullOrEmpty(Patient.CityName))
            {
                try
                { 
                    Patient.CuratorId = Properties.Settings.Default.CurrentCuratorId;
                    Patient.CreateDate = DateTime.Now;
                    DbContext.Patients.Add(Patient);
                    DbContext.DetectAndSaveChanges();

                    Navigation.NavigateTo(new RedirectMessage(), new RedirectMessageViewModel("Добавление прошло успешно", 1000,
                        new CuratorView()));
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
            Navigation.NavigateTo(new CuratorViewModel());
        }
        #endregion

    }
}
