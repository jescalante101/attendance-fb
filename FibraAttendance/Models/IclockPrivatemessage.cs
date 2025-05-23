using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("iclock_privatemessage")]
[Index("EmployeeId", Name = "iclock_privatemessage_employee_id_e84a34c0")]
public partial class IclockPrivatemessage
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

    [Column("start_time", TypeName = "datetime")]
    public DateTime StartTime { get; set; }

    [Column("duration")]
    public int Duration { get; set; }

    [Column("content")]
    public string Content { get; set; } = null!;

    [Column("last_send", TypeName = "datetime")]
    public DateTime? LastSend { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Column("uid")]
    [StringLength(36)]
    public string? Uid { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("IclockPrivatemessages")]
    public virtual PersonnelEmployee Employee { get; set; } = null!;
}
