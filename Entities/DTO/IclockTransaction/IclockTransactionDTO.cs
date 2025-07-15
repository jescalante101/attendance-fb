using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.IclockTransaction
{
    public class IclockTransactionDTO
    {
        public int Id { get; set; }
        public string EmpCode { get; set; }
        public DateTime PunchTime { get; set; }
        public string PunchState { get; set; }
        public int VerifyType { get; set; }
        public string? WorkCode { get; set; }
        public string? TerminalSn { get; set; }
        public string? TerminalAlias { get; set; }
        public string? AreaAlias { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public string? GpsLocation { get; set; }
        public string? Mobile { get; set; }
        public short? Source { get; set; }
        public short? Purpose { get; set; }
        public string? Crc { get; set; }
        public short? IsAttendance { get; set; }
        public DateTime? UploadTime { get; set; }
        public short? SyncStatus { get; set; }
        public DateTime? SyncTime { get; set; }
        public int? EmpId { get; set; }
        public int? TerminalId { get; set; }
        public short? IsMask { get; set; }
        public decimal? Temperature { get; set; }
    }

}
