using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("iclock_terminalworkcode")]
[Index("Code", Name = "UQ__iclock_t__357D4CF90FA7768B", IsUnique = true)]
public partial class IclockTerminalworkcode
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

    [Column("code")]
    [StringLength(8)]
    public string Code { get; set; } = null!;

    [Column("alias")]
    [StringLength(24)]
    public string Alias { get; set; } = null!;

    [Column("last_activity", TypeName = "datetime")]
    public DateTime? LastActivity { get; set; }
}
