namespace FibraAttendance.DTOs
{
    public class TransactionEmployeeDepartmentDto
    {
        public string IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Departamento { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public int EstadoMarcacion { get; set; }
        public short? ConMascarilla { get; set; }
        public decimal? Temperatura { get; set; }
        public string? Area { get; set; }
        public string? NumeroSerie { get; set; }
        public string? NombreDispositivo { get; set; }
        public DateTime? CargarHora { get; set; }
        public string? Cargo { get; set; }
    }
}
