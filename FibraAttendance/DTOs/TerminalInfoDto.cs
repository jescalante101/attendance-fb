namespace FibraAttendance.DTOs
{
    public class TerminalInfoDto
    {
        public int IdTerminal { get; set; }
        public string NumeroDeSerie { get; set; }
        public string Nombre { get; set; }
        public string Area { get; set; }
        public string IpDispositivo { get; set; }
        public int Estado { get; set; }
        public DateTime? UltimaActividad { get; set; }
        public int? Usuarios { get; set; }
        public int? Huella { get; set; }
        public int? Rostro { get; set; }
        public int? Palma { get; set; }
        public int? Marcaciones { get; set; }
        public string? Cmd { get; set; }
        public string? Modelo { get; set; }
    }
}
