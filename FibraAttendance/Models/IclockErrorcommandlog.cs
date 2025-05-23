using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("iclock_errorcommandlog")]
[Index("TerminalId", Name = "iclock_errorcommandlog_terminal_id_3b2d7cbd")]
public partial class IclockErrorcommandlog
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("create_time", TypeName = "datetime")]
    public DateTime? CreateTime { get; set; }

    [Column("create_user")]
    [StringLength(150)]
    public string? CreateUser { get; set; }

    [Column("change_time", TypeName = "datetime")]
    public DateTime? ChangeTime { get; set; }

    [Column("change_user")]
    [StringLength(150)]
    public string? ChangeUser { get; set; }

    [Column("status")]
    public short Status { get; set; }

    [Column("error_code")]
    [StringLength(16)]
    public string? ErrorCode { get; set; }

    [Column("error_msg")]
    [StringLength(50)]
    public string? ErrorMsg { get; set; }

    [Column("data_origin")]
    public string? DataOrigin { get; set; }

    [Column("cmd")]
    [StringLength(50)]
    public string? Cmd { get; set; }

    [Column("additional")]
    public string? Additional { get; set; }

    [Column("upload_time", TypeName = "datetime")]
    public DateTime UploadTime { get; set; }

    [Column("terminal_id")]
    public int TerminalId { get; set; }

    [ForeignKey("TerminalId")]
    [InverseProperty("IclockErrorcommandlogs")]
    public virtual IclockTerminal Terminal { get; set; } = null!;
}
