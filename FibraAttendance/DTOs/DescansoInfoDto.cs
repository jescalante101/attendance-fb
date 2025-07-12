namespace FibraAttendance.DTOs
{
    public class DescansoInfoDto
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string PeriodStart { get; set; }
        public int Duration { get; set; }
        public int FuncKey { get; set; }
        public int AvailableIntervalType { get; set; }
        public int AvailableInterval { get; set; }
        public int MultiplePunch { get; set; }
        public int CalcType { get; set; }
        public int MinimumDuration { get; set; }
        public int EarlyIn { get; set; }
        public string EndMargin { get; set; }
        public int LateIn { get; set; }
        public int MinEarlyIn { get; set; }
        public int MinLateIn { get; set; }
    }
}
