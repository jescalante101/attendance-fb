using FibraAttendance.Infrastructure.Core.Infrastructure;
using FibraAttendance.Infrastructure.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zkemkeeper;

namespace FibraAttendance.Infrastructure.Service
{
    public class ZktecoDeviceService : IZktecoService, IDisposable
    {
        private readonly CZKEM _zkem;
        private bool _isConnected = false;
        private int _machineNumber = 1;
        private string _ipAddress;
        private int _port;


        public ZktecoDeviceService()
        {
            _zkem = new CZKEM();
        }

        public bool Connect(string ipAddress, int port)
        {
            _ipAddress = ipAddress;
            _port = port;
            if (!_isConnected)
            {
                _isConnected = _zkem.Connect_Net(_ipAddress, _port);
            }
            return _isConnected;
        }

        public void Disconnect()
        {
            if (_isConnected)
            {
                _zkem.Disconnect();
                _isConnected = false;
            }
        }

        public async Task<List<AttendanceUser>> GetUsersAsync()
        {

            Console.WriteLine("Estado de Conexion: " + _isConnected);

            if (!_isConnected)
            {
                throw new InvalidOperationException("No se ha conectado al dispositivo.");
            }

            var users = new List<AttendanceUser>();
            string name = "";
            string password = "";
            int privilege = 0;
            bool enabled = false;
            string enrollNumber = "";

            int userId = 0;

            //_zkem.ReadAllUserID(_machineNumber);

            //if (_zkem.GetUserInfo(_machineNumber, userId, name, password, privilege, enabled))
            //{
            //    //enabled = enabledInt == 1;
            //    users.Add(new AttendanceUser { UserId = userId, Name = name, Password = password, Privilege = privilege, Enabled = enabled });

            //    while (_zkem.SSR_GetUserInfo(_machineNumber, userId.ToString(), out name, out password, out privilege, out enabled))
            //    {
            //        //enabled = enabledInt == 1;
            //        users.Add(new AttendanceUser { UserId = userId, Name = name, Password = password, Privilege = privilege, Enabled = enabled });
            //    }
            //}
            _zkem.EnableDevice(_machineNumber, false); // Deshabilitar el dispositivo para la comunicación
            string cardNum = string.Empty;

            while (_zkem.SSR_GetAllUserInfo(_machineNumber, out enrollNumber, out name, out password, out privilege, out enabled))
            {
                cardNum = "";
                if (_zkem.GetStrCardNumber(out cardNum))
                {
                    if (string.IsNullOrEmpty(cardNum))
                        cardNum = "";
                }
                if (!string.IsNullOrEmpty(name))
                {
                    int index = name.IndexOf("\0");
                    if (index > 0)
                    {
                        name = name.Substring(0, index);
                    }
                }

                AttendanceUser empleado = new AttendanceUser
                {
                    UserId = enrollNumber,
                    Name = name.Trim(),
                    Password = password,
                    Privilege = privilege,
                    Enabled = enabled
                };
                users.Add(empleado);
            }

            _zkem.EnableDevice(_machineNumber, true);

            return users;
        }

        public async Task<List<AttendanceRecord>> GetAllAttendanceRecordsAsync()
        {
            if (!_isConnected)
            {
                throw new InvalidOperationException("No se ha conectado al dispositivo.");
            }

            var records = new List<AttendanceRecord>();
            var machineNumber = 1;
            if (records.Count == 0) // Solo si no se obtuvieron registros con la lectura masiva
            {
                string enrollNumber;
                int verifyMode, inOutMode;
                int year, month, day, hour, minute, second;
                int workCode = 0;

                Console.WriteLine("Leyendo registros de asistencia individualmente:");

                while (_zkem.SSR_GetGeneralLogData(
                    machineNumber,
                    out enrollNumber,
                    out verifyMode,
                    out inOutMode,
                    out year,
                    out month,
                    out day,
                    out hour,
                    out minute,
                    out second,
                    ref workCode))
                {
                    DateTime dt = new DateTime(year, month, day, hour, minute, second);
                    
                    string tipo = (inOutMode == 0) ? "Entrada" : "Salida";

                    records.Add(new AttendanceRecord
                    {
                        EnrollNumber = enrollNumber,
                        Timestamp = dt,
                        RecordType = tipo
                        // Puedes agregar verifyMode y workCode si los necesitas en tu modelo
                    });
                }
            }

            return records;
        }

        public async Task<List<AttendanceRecord>> GetTodayAttendanceRecordsAsync()
        {
            if (!_isConnected)
            {
                throw new InvalidOperationException("No se ha conectado al dispositivo.");
            }

            var records = new List<AttendanceRecord>();
            var machineNumber = 1;
            if (records.Count == 0) // Solo si no se obtuvieron registros con la lectura masiva
            {
                string enrollNumber;
                int verifyMode, inOutMode;
                int year, month, day, hour, minute, second;
                int workCode = 0;

                DateTime hoy = DateTime.Now.Date;
                // Define el inicio del día (00:00:00)
                DateTime inicioDelDia = hoy.AddHours(0).AddMinutes(0).AddSeconds(0);

                // Define el fin del día (23:59:59)
                DateTime finDelDia = hoy.AddHours(23).AddMinutes(59).AddSeconds(59);

                // Formatea las fechas a strings
                string inicioDelDiaString = inicioDelDia.ToString("yyyy-MM-dd HH:mm:ss");
                string finDelDiaString = finDelDia.ToString("yyyy-MM-dd HH:mm:ss");

                Console.WriteLine("Leyendo registros de asistencia individualmente:");

                if (_zkem.ReadTimeGLogData(machineNumber,inicioDelDiaString,finDelDiaString))
                {
                    while (_zkem.SSR_GetGeneralLogData(
                    machineNumber,
                    out enrollNumber,
                    out verifyMode,
                    out inOutMode,
                    out year,
                    out month,
                    out day,
                    out hour,
                    out minute,
                    out second,
                    ref workCode))
                    {
                        DateTime dt = new DateTime(year, month, day, hour, minute, second);

                        string tipo = (inOutMode == 0) ? "Entrada" : "Salida";

                        records.Add(new AttendanceRecord
                        {
                            EnrollNumber = enrollNumber,
                            Timestamp = dt,
                            RecordType = tipo

                            // Puedes agregar verifyMode y workCode si los necesitas en tu modelo
                        });
                    }

                }

            }

            return records;
        }


        public async Task<List<AttendanceRecord>> GetLastAttendanceRecord()
        {

            if (!_isConnected)
            {
                throw new InvalidOperationException("No se ha conectado al dispositivo.");
            }

            var records = new List<AttendanceRecord>();
            var machineNumber = 1;
            if (records.Count == 0) // Solo si no se obtuvieron registros con la lectura masiva
            {
                string enrollNumber;
                int verifyMode, inOutMode;
                int year, month, day, hour, minute, second;
                int workCode = 0;



                if (_zkem.ReadNewGLogData(machineNumber))
                {
                    while (_zkem.SSR_GetGeneralLogData(
                    machineNumber,
                    out enrollNumber,
                    out verifyMode,
                    out inOutMode,
                    out year,
                    out month,
                    out day,
                    out hour,
                    out minute,
                    out second,
                    ref workCode))
                    {
                        DateTime dt = new DateTime(year, month, day, hour, minute, second);

                        string tipo = (inOutMode == 0) ? "Entrada" : "Salida";

                        records.Add(new AttendanceRecord
                        {
                            EnrollNumber = enrollNumber,
                            Timestamp = dt,
                            RecordType = tipo
                            // Puedes agregar verifyMode y workCode si los necesitas en tu modelo
                        });
                    }
                }
            }
            return records;
        }

        public void Dispose()
        {
            Disconnect();
            _zkem?.Disconnect();
        }
    }

}
