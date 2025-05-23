using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("iclock_terminaluploadlog")]
[Index("TerminalId", Name = "iclock_terminaluploadlog_terminal_id_9c9a7664")]
public partial class IclockTerminaluploadlog
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("event")]
    [StringLength(80)]
    public string Event { get; set; } = null!;

    [Column("content")]
    [StringLength(80)]
    public string Content { get; set; } = null!;

    [Column("upload_count")]
    public int UploadCount { get; set; }

    [Column("error_count")]
    public int ErrorCount { get; set; }

    [Column("upload_time", TypeName = "datetime")]
    public DateTime UploadTime { get; set; }

    [Column("terminal_id")]
    public int TerminalId { get; set; }

    [ForeignKey("TerminalId")]
    [InverseProperty("IclockTerminaluploadlogs")]
    public virtual IclockTerminal Terminal { get; set; } = null!;
}
