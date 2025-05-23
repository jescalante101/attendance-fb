using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_breaktime")]
[Index("Alias", Name = "att_breaktime_alias_6212d9cf_uniq", IsUnique = true)]
public partial class AttBreaktime
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("alias")]
    [StringLength(50)]
    public string Alias { get; set; } = null!;

    [Column("period_start", TypeName = "datetime")]
    public DateTime PeriodStart { get; set; }

    [Column("duration")]
    public int Duration { get; set; }

    [Column("func_key")]
    public short FuncKey { get; set; }

    [Column("available_interval_type")]
    public short AvailableIntervalType { get; set; }

    [Column("available_interval")]
    public int AvailableInterval { get; set; }

    [Column("multiple_punch")]
    public short MultiplePunch { get; set; }

    [Column("calc_type")]
    public short CalcType { get; set; }

    [Column("minimum_duration")]
    public int? MinimumDuration { get; set; }

    [Column("early_in")]
    public short EarlyIn { get; set; }

    [Column("end_margin")]
    public int EndMargin { get; set; }

    [Column("late_in")]
    public short LateIn { get; set; }

    [Column("min_early_in")]
    public int MinEarlyIn { get; set; }

    [Column("min_late_in")]
    public int MinLateIn { get; set; }

    [InverseProperty("Breaktime")]
    public virtual ICollection<AttTimeintervalBreakTime> AttTimeintervalBreakTimes { get; set; } = new List<AttTimeintervalBreakTime>();
}
