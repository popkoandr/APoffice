using System;
using System.Collections.Generic;
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
        private Guid _userId;
        public Guid UserId { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }

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
            UserId = SequentialGuidGenerator.CreateGuid();
            //Name = "qqqqq";
            //Surname = "aaaaa";

        }

        public Employee(string name, string surname):this()
        {
            Name = name;
            Surname = surname;
            MessageBox.Show(UserId.ToString() + Name);

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
