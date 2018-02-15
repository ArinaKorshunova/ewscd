using DataLayer.Context;
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
    public class DoctorViewModel : Page
    {
        public EwscdContext DbContext { get; set; }

        #region Свойства зависимости

        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(DoctorViewModel), new PropertyMetadata(null));


        public DelegateCommand CheckAsHeldCommand
        {
            get { return (DelegateCommand)GetValue(CheckAsHeldCommandProperty); }
            set { SetValue(CheckAsHeldCommandProperty, value); }
        }
        
        public static readonly DependencyProperty CheckAsHeldCommandProperty =
            DependencyProperty.Register("CheckAsHeldCommand", typeof(DelegateCommand), typeof(DoctorViewModel), new PropertyMetadata(null));
        

        public List<DataLayer.Entities.Action> Actions
        {
            get { return (List<DataLayer.Entities.Action>)GetValue(ActionsProperty); }
            set { SetValue(ActionsProperty, value); }
        }
        
        public static readonly DependencyProperty ActionsProperty =
            DependencyProperty.Register("Actions", typeof(List<DataLayer.Entities.Action>), typeof(DoctorViewModel), new PropertyMetadata(null));



        public DataLayer.Entities.Action SelectedAction
        {
            get { return (DataLayer.Entities.Action)GetValue(SelectedActionProperty); }
            set { SetValue(SelectedActionProperty, value); }
        }
        
        public static readonly DependencyProperty SelectedActionProperty =
            DependencyProperty.Register("SelectedAction", typeof(DataLayer.Entities.Action), typeof(DoctorViewModel), new PropertyMetadata(null));


        #endregion

        #region Конструкторы

        public DoctorViewModel()
        {
            DbContext = new EwscdContext();

            Actions = DbContext.Action.Where(x => x.DoctorId == Properties.Settings.Default.CurrentDoctorId).ToList();

            CheckAsHeldCommand = new DelegateCommand(CheckAsHeld);
        }

        #endregion

        #region Методы 

        private void CheckAsHeld()
        {
            if (SelectedAction != null && !string.IsNullOrEmpty(SelectedAction.DoctorsCommnet))
            {
                try
                {
                    SelectedAction.WasHeld = true;
                    DbContext.DetectAndSaveChanges();

                    Navigation.NavigateTo(new RedirectMessage(), new RedirectMessageViewModel("Сохранено успешно успешно", 1000,
                        new DoctorView()));
                }
                catch (Exception ex)
                {
                    ErrorMessage = $"При выполнении операции возникла следующая ошибка: {ex.Message}";
                    return;
                };
            }
            else
            {
                ErrorMessage = "Необходимо выбрать действие и добавить комментарий!";
            }
        }
        
        #endregion
    }
}
