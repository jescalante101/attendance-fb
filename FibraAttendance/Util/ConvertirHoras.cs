using Microsoft.AspNetCore.Http;
using Microsoft.SqlServer.Server;
using System.Globalization;

namespace FibraAttendance.Util
{
    public class ConvertirHoras
    {

        //DateTime _date;

        public ConvertirHoras()
        {
        }

        public static string ExtraerHoras(DateTime date)
        {
            return date.ToString("HH:mm:ss");
        }

        public static string AgregarMinutos(int minutos,DateTime date)
        {
            var newDate=date.AddMinutes(minutos);
            return newDate.ToString("HH:mm:ss");
        }

        public static string RestarMinutos(int minutos,DateTime date)
        {
            var newDate = date.AddMinutes(-minutos);
            return newDate.ToString("HH:mm:ss");
        }
        public static DateTime StringToDateTime(string hour)
        {
            string formato = "HH:mm:ss";
            DateTime dateTimeObjeto = DateTime.ParseExact(hour, formato, CultureInfo.InvariantCulture);
            return dateTimeObjeto;
        }

        public static double? ObtenerDiferenciaEnMinutos(string horaInicioString, string horaFinString)
        {
            string formato = "HH:mm:ss";
            DateTime horaInicio;
            DateTime horaFin;

            // Intentar parsear la hora de inicio
            if (!DateTime.TryParseExact(horaInicioString, formato, CultureInfo.InvariantCulture, DateTimeStyles.None, out horaInicio))
            {
                Console.WriteLine($"Error: El formato de '{horaInicioString}' no es válido o la hora es incorrecta.");
                return null;
            }

            // Intentar parsear la hora de fin
            if (!DateTime.TryParseExact(horaFinString, formato, CultureInfo.InvariantCulture, DateTimeStyles.None, out horaFin))
            {
                Console.WriteLine($"Error: El formato de '{horaFinString}' no es válido o la hora es incorrecta.");
                return null;
            }

            // Si la hora de fin es menor que la de inicio, asumimos que es al día siguiente
            if (horaFin < horaInicio)
            {
                horaFin = horaFin.AddDays(1);
            }

            // Calcular la diferencia de tiempo
            TimeSpan diferencia = horaFin - horaInicio;

            // Retornar la diferencia total en minutos
            return diferencia.TotalMinutes;
        }

    }
}
