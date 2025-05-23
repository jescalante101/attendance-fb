using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("iclock_terminalparameter")]
[Index("TerminalId", Name = "iclock_terminalparameter_terminal_id_443872e3")]
[Index("TerminalId", "ParamName", Name = "iclock_terminalparameter_terminal_id_param_name_8abbb5c0_uniq", IsUnique = true)]
public partial class IclockTerminalparameter
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("param_type")]
    [StringLength(10)]
    public string? ParamType { get; set; }

    [Column("param_name")]
    [StringLength(30)]
    public string ParamName { get; set; } = null!;

    [Column("param_value")]
    [StringLength(100)]
    public string ParamValue { get; set; } = null!;

    [Column("terminal_id")]
    public int TerminalId { get; set; }

    [ForeignKey("TerminalId")]
    [InverseProperty("IclockTerminalparameters")]
    public virtual IclockTerminal Terminal { get; set; } = null!;
}
