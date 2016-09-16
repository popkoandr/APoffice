using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APoffice.Model
{
    public class Branch
    {
        
        [Key]
        public Guid Id { get; set; }
        public string CityName { get; set; }
        public string Adress { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public Branch()
        {
            Id = SequentialGuidGenerator.CreateGuid();
            Employees = new List<Employee>();
        }

    }
}
