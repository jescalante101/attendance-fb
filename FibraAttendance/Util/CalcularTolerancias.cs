using System.Globalization;

namespace FibraAttendance.Util
{
    public class CalcularTolerancias
    {

        public class ResultadoCalculo
        {
            public double TiempoTrabajoMinutos { get; set; }
            public double ToleranciaEntradaDesdeMinutos { get; set; }
            public double ToleranciaEntradaHastaMinutos { get; set; }
            public double ToleranciaSalidaDesdeMinutos { get; set; }
            public double ToleranciaSalidaHastaMinutos { get; set; }
        }

        public static ResultadoCalculo ObtenerTolerancias(
        string fechaHoraIngresoString,           // Fecha y hora programada de ingreso (ej: "2024-01-15 20:00:00")
        string fechaHoraSalidaString,            // Fecha y hora programada de salida (ej: "2024-01-16 05:00:00")
        string fechaHoraEntradaDesdeString,      // Desde cuando puede marcar entrada (ej: "2024-01-15 19:00:00")
        string fechaHoraEntradaHastaString,      // Hasta cuando puede marcar entrada (ej: "2024-01-16 22:00:00")
        string fechaHoraSalidaDesdeString,       // Desde cuando puede marcar salida (ej: "2024-01-16 01:30:00")
        string fechaHoraSalidaHastaString)       // Hasta cuando puede marcar salida (ej: "2024-01-16 10:00:00")
        {
            var resultado = new ResultadoCalculo();

            try
            {
                // Parsear todas las fechas y horas - mucho más simple!
                var fechaHoraIngreso = ParsearFechaHora(fechaHoraIngresoString);
                var fechaHoraSalida = ParsearFechaHora(fechaHoraSalidaString);
                var fechaHoraEntradaDesde = ParsearFechaHora(fechaHoraEntradaDesdeString);
                var fechaHoraEntradaHasta = ParsearFechaHora(fechaHoraEntradaHastaString);
                var fechaHoraSalidaDesde = ParsearFechaHora(fechaHoraSalidaDesdeString);
                var fechaHoraSalidaHasta = ParsearFechaHora(fechaHoraSalidaHastaString);

                // Cálculos directos - sin complicaciones de detectar día siguiente!

                // 1. Tiempo de trabajo = fecha/hora salida - fecha/hora ingreso
                var tiempoTrabajo = fechaHoraSalida - fechaHoraIngreso;
                resultado.TiempoTrabajoMinutos = tiempoTrabajo.TotalMinutes;

                // 2. Tolerancia entrada desde = fecha/hora ingreso - fecha/hora entrada desde
                var toleranciaEntradaDesde = fechaHoraIngreso - fechaHoraEntradaDesde;
                resultado.ToleranciaEntradaDesdeMinutos = toleranciaEntradaDesde.TotalMinutes;

                // 3. Tolerancia entrada hasta = fecha/hora entrada hasta - fecha/hora ingreso
                var toleranciaEntradaHasta = fechaHoraEntradaHasta - fechaHoraIngreso;
                resultado.ToleranciaEntradaHastaMinutos = toleranciaEntradaHasta.TotalMinutes;

                // 4. Tolerancia salida desde = fecha/hora salida - fecha/hora salida desde
                var toleranciaSalidaDesde = fechaHoraSalida - fechaHoraSalidaDesde;
                resultado.ToleranciaSalidaDesdeMinutos = toleranciaSalidaDesde.TotalMinutes;

                // 5. Tolerancia salida hasta = fecha/hora salida hasta - fecha/hora salida
                var toleranciaSalidaHasta = fechaHoraSalidaHasta - fechaHoraSalida;
                resultado.ToleranciaSalidaHastaMinutos = toleranciaSalidaHasta.TotalMinutes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en el cálculo: {ex.Message}");
                return null;
            }

            return resultado;
        }

        private static DateTime ParsearFechaHora(string fechaHora)
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

    }
}
