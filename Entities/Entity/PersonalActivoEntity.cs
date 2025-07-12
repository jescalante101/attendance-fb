using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    public class ActiveEmployeeEntity
    {

        public string EmployeeId { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FirstNames { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string DocumentNumber { get; set; }
    }
}
