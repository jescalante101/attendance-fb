using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("iclock_terminallog")]
[Index("TerminalId", Name = "iclock_terminallog_terminal_id_667b3ea7")]
public partial class IclockTerminallog
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("terminal_tz")]
    public short? TerminalTz { get; set; }

    [Column("admin")]
    [StringLength(50)]
    public string? Admin { get; set; }

    [Column("action_name")]
    public short? ActionName { get; set; }

    [Column("action_time", TypeName = "datetime")]
    public DateTime? ActionTime { get; set; }

    [Column("object")]
    [StringLength(50)]
    public string? Object { get; set; }

    [Column("param1")]
    public int? Param1 { get; set; }

    [Column("param2")]
    public int? Param2 { get; set; }

    [Column("param3")]
    public int? Param3 { get; set; }

    [Column("upload_time", TypeName = "datetime")]
    public DateTime? UploadTime { get; set; }

    [Column("terminal_id")]
    public int TerminalId { get; set; }

    [ForeignKey("TerminalId")]
    [InverseProperty("IclockTerminallogs")]
    public virtual IclockTerminal Terminal { get; set; } = null!;
}
