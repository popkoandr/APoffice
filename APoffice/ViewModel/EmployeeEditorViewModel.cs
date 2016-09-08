using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using APoffice.Model;
using APoffice.ViewModel.ViewModelBase;
//using Shell.ViewModels.VMBase;

namespace APoffice.ViewModel
{
    public class EmployeeEditorViewModel:Shell.ViewModels.VMBase.ViewModelBase
    {
        Employee _currentEmployee;
        Employee _editingEmployee;

        public Employee EditingEmployee
        {
            get
            {
                //MessageBox.Show("get " + _editingEmployee);
                return _editingEmployee;
                
            }
            set
            {
                _editingEmployee = value;
                //OnPropertyChanged("EditingEmployee"); //no need to say all that this was changed???
               // MessageBox.Show("set " + _editingEmployee);
            } 
        } //

        public Employee CurrentEmployee
        {
            get
            {
                if (_currentEmployee==null)
                    _currentEmployee = new Employee();
                return _currentEmployee;

            }
            set
            {
                _currentEmployee = value;
                OnPropertyChanged("CurrentEmployee");//says to all that property "CurrentEmployee" changed

            }
        }

        ObservableCollection<Employee> _employees; 

        public ObservableCollection<Employee> Employees
        {
            get
            {
                if (_employees == null)
                    _employees = EmployeeRepository.AllEmployees;
                return _employees;

            }
        }

       

        #region Add Employee

        RelayCommand _addEmployeeCommand;
        public ICommand AddEmployee
        {
            get
            {
                if(_addEmployeeCommand==null)
                    _addEmployeeCommand = new RelayCommand(ExecuteAddEmployeeCommand,CanExecuteAddEmployeeCommand);
                return _addEmployeeCommand;
            }
        }
        public void ExecuteAddEmployeeCommand(object parameter)
        {
            if (Employees.Contains(CurrentEmployee))
            {
                //realize editing
            }
            else
                Employees.Add(CurrentEmployee);
            CurrentEmployee = null;
          // OnPropertyChanged("Employees");
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

        RelayCommand _startEditingEmployeeCommand;
        
        public ICommand StartEditing
        {
            get
            {
                if(_startEditingEmployeeCommand==null)
                    _startEditingEmployeeCommand = new RelayCommand(ExecuteStartEditingCommand,CanExecuteStartEditingCommand);
                return _startEditingEmployeeCommand;
            }
        }

        public void ExecuteStartEditingCommand(object parametr)
        {
            CurrentEmployee = EditingEmployee;
        }

        public bool CanExecuteStartEditingCommand(object parametr)
        {
            //if (string.IsNullOrEmpty(CurrentEmployee.Name) ||
            //    string.IsNullOrEmpty(CurrentEmployee.Surname))
            //    return false;
            return true;
        }
        #endregion

    }
}
