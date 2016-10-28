using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace APoffice.Model
{
    public class Employee
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public Guid? BranchId { get; set; }
        public Branch Branch { get; set; }


        #region test static costruct
        ////public static int Numb;
        //static Employee()
        //{
        //    //Numb = 10;
        //    MessageBox.Show("Static construct");
        //}
#endregion
        public Employee()
        {
             Id = SequentialGuidGenerator.CreateGuid();
        }

        public Employee(string name, string surname):this()
        {
            Name = name;
            Surname = surname;
           // MessageBox.Show(Id.ToString() + Name);

        }
        //public void ShowInfo()
        //{
        //    MessageBox.Show(string.Format("Employee: {0} {1} {2} \n Date of birth: {3}", Surname, Name, Patronymic,
        //        DateOfBirth));
        //    //MessageBox.Show($"Employee: {Surname} {Name} {SecondName} \n Date of birth: {DateOfBirth}");
        //}

        public override string ToString()
        {
            return String.Format("{0} {1}", Name, Surname);
        }
    }
}
