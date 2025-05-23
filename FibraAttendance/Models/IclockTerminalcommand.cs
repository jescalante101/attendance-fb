using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("iclock_terminalcommand")]
[Index("TerminalId", Name = "iclock_terminalcommand_terminal_id_3dcf836f")]
public partial class IclockTerminalcommand
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("content")]
    public string Content { get; set; } = null!;

    [Column("commit_time", TypeName = "datetime")]
    public DateTime CommitTime { get; set; }

    [Column("transfer_time", TypeName = "datetime")]
    public DateTime? TransferTime { get; set; }

    [Column("return_time", TypeName = "datetime")]
    public DateTime? ReturnTime { get; set; }

    [Column("return_value")]
    public int? ReturnValue { get; set; }

    [Column("terminal_id")]
    public int TerminalId { get; set; }

    [ForeignKey("TerminalId")]
    [InverseProperty("IclockTerminalcommands")]
    public virtual IclockTerminal Terminal { get; set; } = null!;
}
