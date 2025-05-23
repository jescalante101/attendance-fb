using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("iclock_transactionproofcmd")]
[Index("TerminalId", Name = "iclock_transactionproofcmd_terminal_id_08b81e1e")]
public partial class IclockTransactionproofcmd
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("action_time", TypeName = "datetime")]
    public DateTime ActionTime { get; set; }

    [Column("start_time", TypeName = "datetime")]
    public DateTime StartTime { get; set; }

    [Column("end_time", TypeName = "datetime")]
    public DateTime EndTime { get; set; }

    [Column("terminal_count")]
    public int? TerminalCount { get; set; }

    [Column("server_count")]
    public int? ServerCount { get; set; }

    [Column("flag")]
    public short? Flag { get; set; }

    [Column("reserved_init")]
    public int? ReservedInit { get; set; }

    [Column("reserved_float")]
    public double? ReservedFloat { get; set; }

    [Column("reserved_char")]
    [StringLength(30)]
    public string? ReservedChar { get; set; }

    [Column("terminal_id")]
    public int TerminalId { get; set; }

    [ForeignKey("TerminalId")]
    [InverseProperty("IclockTransactionproofcmds")]
    public virtual IclockTerminal Terminal { get; set; } = null!;
}
