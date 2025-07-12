using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class EmployeeScheduleDto
    {
        public int Id { get; set; }
        public string FullNameEmployee { get; set; }
        public string Alias { get; set; }
        public string InTime { get; set; }
        // tiempo de salida
        public string OutTime { get; set; }
    }
}
