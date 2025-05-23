using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("djcelery_periodictask")]
[Index("Name", Name = "UQ__djcelery__72E12F1B0BE30209", IsUnique = true)]
[Index("CrontabId", Name = "djcelery_periodictask_crontab_id_75609bab")]
[Index("IntervalId", Name = "djcelery_periodictask_interval_id_b426ab02")]
public partial class DjceleryPeriodictask
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(200)]
    public string Name { get; set; } = null!;

    [Column("task")]
    [StringLength(200)]
    public string Task { get; set; } = null!;

    [Column("args")]
    public string Args { get; set; } = null!;

    [Column("kwargs")]
    public string Kwargs { get; set; } = null!;

    [Column("queue")]
    [StringLength(200)]
    public string? Queue { get; set; }

    [Column("exchange")]
    [StringLength(200)]
    public string? Exchange { get; set; }

    [Column("routing_key")]
    [StringLength(200)]
    public string? RoutingKey { get; set; }

    [Column("expires", TypeName = "datetime")]
    public DateTime? Expires { get; set; }

    [Column("enabled")]
    public bool Enabled { get; set; }

    [Column("last_run_at", TypeName = "datetime")]
    public DateTime? LastRunAt { get; set; }

    [Column("total_run_count")]
    public int TotalRunCount { get; set; }

    [Column("date_changed", TypeName = "datetime")]
    public DateTime DateChanged { get; set; }

    [Column("description")]
    public string Description { get; set; } = null!;

    [Column("crontab_id")]
    public int? CrontabId { get; set; }

    [Column("interval_id")]
    public int? IntervalId { get; set; }

    [ForeignKey("CrontabId")]
    [InverseProperty("DjceleryPeriodictasks")]
    public virtual DjceleryCrontabschedule? Crontab { get; set; }

    [ForeignKey("IntervalId")]
    [InverseProperty("DjceleryPeriodictasks")]
    public virtual DjceleryIntervalschedule? Interval { get; set; }
}
