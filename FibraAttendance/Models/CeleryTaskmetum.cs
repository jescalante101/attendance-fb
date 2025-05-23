using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("celery_taskmeta")]
[Index("TaskId", Name = "UQ__celery_t__0492148CB965D27B", IsUnique = true)]
[Index("Hidden", Name = "celery_taskmeta_hidden_23fd02dc")]
public partial class CeleryTaskmetum
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("task_id")]
    [StringLength(255)]
    public string TaskId { get; set; } = null!;

    [Column("status")]
    [StringLength(50)]
    public string Status { get; set; } = null!;

    [Column("result")]
    public string? Result { get; set; }

    [Column("date_done", TypeName = "datetime")]
    public DateTime DateDone { get; set; }

    [Column("traceback")]
    public string? Traceback { get; set; }

    [Column("hidden")]
    public bool Hidden { get; set; }

    [Column("meta")]
    public string? Meta { get; set; }
}
