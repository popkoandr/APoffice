using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using APoffice.Model;
using APoffice.RepositoryFolder;
using APoffice.ViewModel.ViewModelBase;
//using Shell.ViewModels.VMBase;

namespace APoffice.ViewModel
{
    public class EmployeeEditorViewModel : Shell.ViewModels.VMBase.ViewModelBase
    {
        Employee _currentEmployee;
        ObservableCollection<Employee> _employees;

        /// <summary>
        /// Selected Employee in Listbox
        /// </summary>
        public Employee SelectedEmployee { get; set; }

        /// <summary>
        /// Employee that creating or changing 
        /// </summary>
        public Employee CurrentEmployee
        {
            get
            {
                if (_currentEmployee == null)
                    _currentEmployee = new Employee();
                return _currentEmployee;
            }
            set
            {
                _currentEmployee = value;
                OnPropertyChanged("CurrentEmployee");// says to all that property "CurrentEmployee" changed
            }
        }

        /// <summary>
        /// Binding Property for all Employee in Datebase
        /// </summary>
        public ObservableCollection<Employee> Employees
        {
            get
            {
                if (_employees == null)
                {
                    var unitOfWork = new UnitOfWork(new EmployeeContext());
                    _employees = new ObservableCollection<Employee>(unitOfWork.Employees.GetAll());// using Repository
                    //var db = new EmployeeContext();
                    //db.Employees.Load();
                    //_employees = db.Employees.Local;
                }
                return _employees;
            }
        }


        #region Add Employee

        RelayCommand _addEmployeeCommand;
        public ICommand AddEmployee
        {
            get
            {
                if (_addEmployeeCommand == null)
                    _addEmployeeCommand = new RelayCommand(ExecuteAddEmployeeCommand, CanExecuteAddEmployeeCommand);
                return _addEmployeeCommand;
            }
        } 
        public void ExecuteAddEmployeeCommand(object parameter)
        {
            using (var unitOfWork = new UnitOfWork(new EmployeeContext()))
            {
                try
                {
                    unitOfWork.Employees.Add(CurrentEmployee);
                    unitOfWork.Complete();
                    //MessageBox.Show("Added");
                    
                    
                   // MessageBox.Show("recieve count =  " + unitOfWork.Employees.GetTopCountEmployees(3).Count());

                  //  MessageBox.Show("With surname Popko count = " +
                                   // unitOfWork.Employees.GetBySurnameEmployees("Popko").Count());
                    unitOfWork.Employees.SGetBranches();
                }
                catch (Exception)
                {
                    
                    throw;
                }
               
            }
            CurrentEmployee = null;
            //using (var db = new EmployeeContext())
            //{
            //    db.Employees.Add(CurrentEmployee);// add to db BUT dont update listBox!!!!!!!!!!!!!
            //    db.SaveChanges();
            //}
            //  MessageBox.Show("New user was added to Database");

            // _employees = null;  OnPropertyChanged("Employees");  - do this for realtime update list, but its not good

        }
        public bool CanExecuteAddEmployeeCommand(object parameter)
        {
            if (string.IsNullOrEmpty(CurrentEmployee.Name) ||
                string.IsNullOrEmpty(CurrentEmployee.Surname))
                return false;
            return true;
        }
        #endregion

        #region Edit existing employee

        private RelayCommand _startEditingEmployeeCommand;
        public ICommand StartEditing
        {
            get
            {
                if (_startEditingEmployeeCommand == null)
                    _startEditingEmployeeCommand = new RelayCommand(ExecuteStartEditingCommand, CanExecuteStartEditingCommand);
                return _startEditingEmployeeCommand;
            }
        }

        public void ExecuteStartEditingCommand(object parametr)
        {
            CurrentEmployee = SelectedEmployee;
        }

        public bool CanExecuteStartEditingCommand(object parametr)
        {
            return true;
        }
        #endregion

    }
}
