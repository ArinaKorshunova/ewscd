using DataLayer.Context;
using DataLayer.Entities;
using EarlyWarningSystem.Model;
using EarlyWarningSystem.NavigationHelper;
using EarlyWarningSystem.View;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EarlyWarningSystem.ViewModel
{
    public class AddNewActionViewModel : Page
    {
        public EwscdContext DbContext { get; set; }
        #region Свойства зависимости

        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(AddNewActionViewModel), new PropertyMetadata(null));
        

        public DataLayer.Entities.Action Action
        {
            get { return (DataLayer.Entities.Action)GetValue(ActionProperty); }
            set { SetValue(ActionProperty, value); }
        }
        
        public static readonly DependencyProperty ActionProperty =
            DependencyProperty.Register("Action", typeof(DataLayer.Entities.Action), typeof(AddNewActionViewModel), new PropertyMetadata(null));
        
        public List<Employee> Doctors
        {
            get { return (List<Employee>)GetValue(DoctorsProperty); }
            set { SetValue(DoctorsProperty, value); }
        }

        public static readonly DependencyProperty DoctorsProperty =
            DependencyProperty.Register("Doctors", typeof(List<Employee>), typeof(AddNewActionViewModel), new PropertyMetadata(null));

        
        public Employee SelectedDoctor
        {
            get { return (Employee)GetValue(SelectedDoctorProperty); }
            set { SetValue(SelectedDoctorProperty, value); }
        }
        
        public static readonly DependencyProperty SelectedDoctorProperty =
            DependencyProperty.Register("SelectedDoctor", typeof(Employee), typeof(AddNewActionViewModel), new PropertyMetadata(null));

        
        public DelegateCommand OkCommand
        {
            get { return (DelegateCommand)GetValue(OkCommandProperty); }
            set { SetValue(OkCommandProperty, value); }
        }
        public static readonly DependencyProperty OkCommandProperty =
            DependencyProperty.Register("OkCommand", typeof(DelegateCommand), typeof(AddNewActionViewModel), new PropertyMetadata(null));


        public DelegateCommand CancelCommand
        {
            get { return (DelegateCommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }
        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register("CancelCommand", typeof(DelegateCommand), typeof(AddNewActionViewModel), new PropertyMetadata(null));
        

        public List<string> KindList
        {
            get { return (List<string>)GetValue(KindListProperty); }
            set { SetValue(KindListProperty, value); }
        }

        public static readonly DependencyProperty KindListProperty =
            DependencyProperty.Register("KindList", typeof(List<string>), typeof(AddNewActionViewModel), new PropertyMetadata(null));



        #endregion

        #region Конструкторы

        public AddNewActionViewModel()
        {
            DbContext = new EwscdContext();
            Doctors = DbContext.Employees.Where(x => x.Role == Const.DoctorRole).OrderBy(x => x.FIO).ToList();
            KindList = new List<string> { Const.AppointmentKind, Const.ProcedureKind };
            Action = new DataLayer.Entities.Action();

            OkCommand = new DelegateCommand(Register);
            CancelCommand = new DelegateCommand(Cancel);
        }

        #endregion

        #region Методы

        private void Register()
        {
            if (SelectedDoctor != null && Action.AppointmentDate != DateTime.MinValue &&
                !String.IsNullOrEmpty(Action.KindAction) && !String.IsNullOrEmpty(Action.Description))
            {
                try
                {
                    Action.DoctorId = SelectedDoctor.Id;
                    Action.PatientId = Properties.Settings.Default.CurrentPatientId;
                    Action.CreateDate = DateTime.Now;
                    DbContext.Action.Add(Action);
                    DbContext.DetectAndSaveChanges();

                    Navigation.NavigateTo(new RedirectMessage(), new RedirectMessageViewModel("Добавление прошло успешно", 1000,
                        new CuratorView()));
                }
                catch (Exception ex)
                {
                    ErrorMessage = $"При выполнении операции возникла следующая ошибка: {ex.Message}";
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
            Navigation.NavigateTo(new CuratorView());
        }
        #endregion

    }
}
