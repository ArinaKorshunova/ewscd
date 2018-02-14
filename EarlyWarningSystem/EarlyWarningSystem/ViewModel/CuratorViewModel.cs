using DataLayer.Context;
using DataLayer.Entities;
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
    public class CuratorViewModel : Page
    {
        public EwscdContext DbContext { get; set; }

        #region Свойства зависиости

        public List<Patient> Patients
        {
            get { return (List<Patient>)GetValue(PatientsProperty); }
            set { SetValue(PatientsProperty, value); }
        }
        public static readonly DependencyProperty PatientsProperty =
            DependencyProperty.Register("Patients", typeof(List<Patient>), typeof(CuratorViewModel), new PropertyMetadata(null));


        public Patient SelectedPatient
        {
            get { return (Patient)GetValue(SelectedPatientProperty); }
            set { SetValue(SelectedPatientProperty, value); }
        }

        public static readonly DependencyProperty SelectedPatientProperty =
            DependencyProperty.Register("SelectedPatient", typeof(Patient), typeof(CuratorViewModel), new PropertyMetadata(null));


        public DelegateCommand SelectedPatientCommand
        {
            get { return (DelegateCommand)GetValue(SelectedPatientCommandProperty); }
            set { SetValue(SelectedPatientCommandProperty, value); }
        }
        public static readonly DependencyProperty SelectedPatientCommandProperty =
            DependencyProperty.Register("SelectedPatientCommand", typeof(DelegateCommand), typeof(CuratorViewModel), new PropertyMetadata(null));

        
        public DelegateCommand AddPatientCommand
        {
            get { return (DelegateCommand)GetValue( AddPatientCommandProperty); }
            set { SetValue( AddPatientCommandProperty, value); }
        }
        
        public static readonly DependencyProperty  AddPatientCommandProperty =
            DependencyProperty.Register(" AddPatientCommand", typeof(DelegateCommand), typeof(CuratorViewModel), new PropertyMetadata(null));




        public List<DataLayer.Entities.Action> Actions
        {
            get { return (List<DataLayer.Entities.Action>)GetValue(ActionsProperty); }
            set { SetValue(ActionsProperty, value); }
        }

        public static readonly DependencyProperty ActionsProperty =
            DependencyProperty.Register("Actions", typeof(List<DataLayer.Entities.Action>), typeof(CuratorViewModel), new PropertyMetadata(null));



        public DataLayer.Entities.Action SelectedAction
        {
            get { return (DataLayer.Entities.Action)GetValue(SelectedActionProperty); }
            set { SetValue(SelectedActionProperty, value); }
        }
        
        public static readonly DependencyProperty SelectedActionProperty =
            DependencyProperty.Register("SelectedAction", typeof(DataLayer.Entities.Action), typeof(CuratorViewModel), new PropertyMetadata(null));
        

        public DelegateCommand AddNewActionCommand
        {
            get { return (DelegateCommand)GetValue(AddNewActionCommandProperty); }
            set { SetValue(AddNewActionCommandProperty, value); }
        }
        
        public static readonly DependencyProperty AddNewActionCommandProperty =
            DependencyProperty.Register("AddNewActionCommand", typeof(DelegateCommand), typeof(CuratorViewModel), new PropertyMetadata(null));




        #endregion

        #region Конструкторы

        public CuratorViewModel()
        {
            DbContext = new EwscdContext();

            Patients = DbContext.Patients.Where(x => x.CuratorId == Properties.Settings.Default.CurrentCuratorId).ToList();

            SelectedPatientCommand = new DelegateCommand(SelectPatient);
            AddPatientCommand = new DelegateCommand(AddPatient);
            AddNewActionCommand = new DelegateCommand(AddNewAction);
        }

        #endregion

        #region Методы 

        private void SelectPatient()
        {
            if (SelectedPatient != null)
            {
                Actions = DbContext.Action.Where(x => x.PatientId == SelectedPatient.Id).OrderByDescending(x => x.AppointmentDate).ToList();
            }
        }
        
        private void AddPatient()
        {
            Navigation.NavigateTo(new AddPatientView());
        }

        private void AddNewAction()
        {
            Navigation.NavigateTo(new AddNewActionView());
        }

        #endregion
    }
}
