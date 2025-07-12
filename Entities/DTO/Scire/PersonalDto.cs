using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Scire
{
    public class PersonalDto
    {
        public string EmployeeId { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FirstNames { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string AuxiliarCatering { get; set; }
        public string DocumentNumber { get; set; }
        public string Telephone { get; set; }
        public string Reference { get; set; }
    }



}
