using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibraAttendance.Infrastructure.Core.Model
{
    public class AttendanceRecord
    {
        public string? EnrollNumber { get; set; }
        public int VerifyMode { get; set; }
        public int InOutMode { get; set; }
        public DateTime Timestamp { get; set; } // Propiedad combinada de fecha y hora
        public string? RecordType { get; set; } // "Entrada" o "Salida" (derivado de InOutMode)
        public int WorkCode { get; set; }


    }
}
