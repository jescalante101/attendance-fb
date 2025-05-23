using FibraAttendance.Infrastructure.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibraAttendance.Infrastructure.Core.Infrastructure
{
    public interface IZktecoService
    {
        bool Connect(string ipAddress, int port);
        void Disconnect();
        Task<List<AttendanceUser>> GetUsersAsync();
        Task<List<AttendanceRecord>> GetAllAttendanceRecordsAsync();
        Task<List<AttendanceRecord>> GetTodayAttendanceRecordsAsync();
    }
}
