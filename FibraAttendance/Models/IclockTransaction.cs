using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("iclock_transaction")]
[Index("EmpCode", "PunchTime", Name = "iclock_transaction_emp_code_punch_time_ca282852_uniq", IsUnique = true)]
[Index("EmpId", Name = "iclock_transaction_emp_id_60fa3521")]
[Index("TerminalId", Name = "iclock_transaction_terminal_id_451c81c2")]
public partial class IclockTransaction
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("emp_code")]
    [StringLength(20)]
    public string EmpCode { get; set; } = null!;

    [Column("punch_time", TypeName = "datetime")]
    public DateTime PunchTime { get; set; }

    [Column("punch_state")]
    [StringLength(5)]
    public string PunchState { get; set; } = null!;

    [Column("verify_type")]
    public int VerifyType { get; set; }

    [Column("work_code")]
    [StringLength(20)]
    public string? WorkCode { get; set; }

    [Column("terminal_sn")]
    [StringLength(50)]
    public string? TerminalSn { get; set; }

    [Column("terminal_alias")]
    [StringLength(50)]
    public string? TerminalAlias { get; set; }

    [Column("area_alias")]
    [StringLength(30)]
    public string? AreaAlias { get; set; }

    [Column("longitude")]
    public double? Longitude { get; set; }

    [Column("latitude")]
    public double? Latitude { get; set; }

    [Column("gps_location")]
    public string? GpsLocation { get; set; }

    [Column("mobile")]
    [StringLength(50)]
    public string? Mobile { get; set; }

    [Column("source")]
    public short? Source { get; set; }

    [Column("purpose")]
    public short? Purpose { get; set; }

    [Column("crc")]
    [StringLength(100)]
    public string? Crc { get; set; }

    [Column("is_attendance")]
    public short? IsAttendance { get; set; }

    [Column("reserved")]
    [StringLength(100)]
    public string? Reserved { get; set; }

    [Column("upload_time", TypeName = "datetime")]
    public DateTime? UploadTime { get; set; }

    [Column("sync_status")]
    public short? SyncStatus { get; set; }

    [Column("sync_time", TypeName = "datetime")]
    public DateTime? SyncTime { get; set; }

    [Column("emp_id")]
    public int? EmpId { get; set; }

    [Column("terminal_id")]
    public int? TerminalId { get; set; }

    [Column("is_mask")]
    public short? IsMask { get; set; }

    [Column("temperature", TypeName = "numeric(4, 1)")]
    public decimal? Temperature { get; set; }

    [InverseProperty("TransIn")]
    public virtual ICollection<AttPayloadbase> AttPayloadbaseTransIns { get; set; } = new List<AttPayloadbase>();

    [InverseProperty("TransOut")]
    public virtual ICollection<AttPayloadbase> AttPayloadbaseTransOuts { get; set; } = new List<AttPayloadbase>();

    [InverseProperty("Orig")]
    public virtual ICollection<AttPayloadpunch> AttPayloadpunches { get; set; } = new List<AttPayloadpunch>();

    [ForeignKey("EmpId")]
    [InverseProperty("IclockTransactions")]
    public virtual PersonnelEmployee? Emp { get; set; }

    [ForeignKey("TerminalId")]
    [InverseProperty("IclockTransactions")]
    public virtual IclockTerminal? Terminal { get; set; }
}
