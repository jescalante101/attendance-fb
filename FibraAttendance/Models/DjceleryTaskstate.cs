using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("djcelery_taskstate")]
[Index("TaskId", Name = "UQ__djcelery__0492148C7CCFF2CA", IsUnique = true)]
[Index("Hidden", Name = "djcelery_taskstate_hidden_c3905e57")]
[Index("Name", Name = "djcelery_taskstate_name_8af9eded")]
[Index("State", Name = "djcelery_taskstate_state_53543be4")]
[Index("Tstamp", Name = "djcelery_taskstate_tstamp_4c3f93a1")]
[Index("WorkerId", Name = "djcelery_taskstate_worker_id_f7f57a05")]
public partial class DjceleryTaskstate
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("state")]
    [StringLength(64)]
    public string State { get; set; } = null!;

    [Column("task_id")]
    [StringLength(36)]
    public string TaskId { get; set; } = null!;

    [Column("name")]
    [StringLength(200)]
    public string? Name { get; set; }

    [Column("tstamp", TypeName = "datetime")]
    public DateTime Tstamp { get; set; }

    [Column("args")]
    public string? Args { get; set; }

    [Column("kwargs")]
    public string? Kwargs { get; set; }

    [Column("eta", TypeName = "datetime")]
    public DateTime? Eta { get; set; }

    [Column("expires", TypeName = "datetime")]
    public DateTime? Expires { get; set; }

    [Column("result")]
    public string? Result { get; set; }

    [Column("traceback")]
    public string? Traceback { get; set; }

    [Column("runtime")]
    public double? Runtime { get; set; }

    [Column("retries")]
    public int Retries { get; set; }

    [Column("hidden")]
    public bool Hidden { get; set; }

    [Column("worker_id")]
    public int? WorkerId { get; set; }

    [ForeignKey("WorkerId")]
    [InverseProperty("DjceleryTaskstates")]
    public virtual DjceleryWorkerstate? Worker { get; set; }
}
