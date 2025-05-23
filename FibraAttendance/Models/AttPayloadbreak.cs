using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_payloadbreak")]
public partial class AttPayloadbreak
{
    [Key]
    [Column("uuid")]
    [StringLength(36)]
    public string Uuid { get; set; } = null!;

    [Column("break_out", TypeName = "datetime")]
    public DateTime? BreakOut { get; set; }

    [Column("break_in", TypeName = "datetime")]
    public DateTime? BreakIn { get; set; }

    [Column("duration")]
    public int? Duration { get; set; }

    [Column("taken")]
    public int? Taken { get; set; }

    [Column("actual_duration")]
    public int? ActualDuration { get; set; }

    [Column("early_in")]
    public int? EarlyIn { get; set; }

    [Column("late_in")]
    public int? LateIn { get; set; }

    [Column("late")]
    public int? Late { get; set; }

    [Column("early_leave")]
    public int? EarlyLeave { get; set; }

    [Column("absent")]
    public int? Absent { get; set; }

    [Column("work_time")]
    public int? WorkTime { get; set; }

    [Column("overtime")]
    public int? Overtime { get; set; }

    [Column("weekend_ot")]
    public int? WeekendOt { get; set; }

    [Column("holiday_ot")]
    public int? HolidayOt { get; set; }
}
