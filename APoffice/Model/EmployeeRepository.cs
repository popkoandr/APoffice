using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APoffice.Model
{
    public static class EmployeeRepository
    {
        private static ObservableCollection<Employee> _employees;

        public static ObservableCollection<Employee> AllEmployees
        {
            get
            {
                if (_employees == null)
                    _employees = GenerateEmployeeRepository();
                return _employees;
            }

        }

        private static ObservableCollection<Employee> GenerateEmployeeRepository()
        {
            var employee = new ObservableCollection<Employee>
            {
                new Employee("Andrew", "Popko"),
                new Employee("Valentyn", "Popko"),
                new Employee("Nataliia", "Popko")
            };
            return employee;
        }  
    }
}
