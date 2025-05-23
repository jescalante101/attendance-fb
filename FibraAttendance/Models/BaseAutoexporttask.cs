using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("base_autoexporttask")]
[Index("TaskCode", Name = "UQ__base_aut__4ED29156B47B2093", IsUnique = true)]
public partial class BaseAutoexporttask
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

    [Column("task_code")]
    [StringLength(30)]
    public string TaskCode { get; set; } = null!;

    [Column("task_name")]
    [StringLength(30)]
    public string TaskName { get; set; } = null!;

    [Column("params")]
    public string? Params { get; set; }
}
