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

         public static DateTime ParsearFechaHora(string fechaHora)
        {
            // Formatos soportados
            string[] formatos = {
            "yyyy-MM-dd HH:mm:ss",
            "yyyy-MM-dd HH:mm",
            "dd/MM/yyyy HH:mm:ss",
            "dd/MM/yyyy HH:mm",
            "yyyy-MM-ddTHH:mm:ss",  // Formato ISO (datetime-local de HTML)
            "yyyy-MM-ddTHH:mm"
        };

            foreach (string formato in formatos)
            {
                if (DateTime.TryParseExact(fechaHora, formato, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime resultado))
                {
                    return resultado;
                }
            }

            // Si ningún formato específico funciona, intentar parseo automático
            if (DateTime.TryParse(fechaHora, out DateTime resultadoAuto))
            {
                return resultadoAuto;
            }

            throw new ArgumentException($"Formato de fecha/hora inválido: {fechaHora}");
        }

        public static int ObtenerDiferenciaEnMinutos(string horaInicioString, string horaFinString)
        {
            string[] formatos = {
                "yyyy-MM-dd HH:mm:ss",
                "yyyy-MM-dd HH:mm",
                "dd/MM/yyyy HH:mm:ss",
                "dd/MM/yyyy HH:mm",
                "yyyy-MM-ddTHH:mm:ss",
                "yyyy-MM-ddTHH:mm"
            };

            if (!DateTime.TryParseExact(horaInicioString, formatos, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime inicio))
                throw new ArgumentException("El formato de fechaHoraInicio no es válido.");

            if (!DateTime.TryParseExact(horaFinString, formatos, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime fin))
                throw new ArgumentException("El formato de fechaHoraFin no es válido.");

            return (int)(fin - inicio).TotalMinutes;
        }

    }
}
