using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("iclock_terminalemployee")]
public partial class IclockTerminalemployee
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("terminal_sn")]
    [StringLength(50)]
    public string TerminalSn { get; set; } = null!;

    [Column("emp_code")]
    [StringLength(20)]
    public string EmpCode { get; set; } = null!;

    [Column("privilege")]
    public short Privilege { get; set; }
}
