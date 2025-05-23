using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_timeinterval")]
public partial class AttTimeinterval
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("alias")]
    [StringLength(50)]
    public string Alias { get; set; } = null!;

    [Column("use_mode")]
    public short UseMode { get; set; }

    [Column("in_time", TypeName = "datetime")]
    public DateTime InTime { get; set; }

    [Column("in_ahead_margin")]
    public int InAheadMargin { get; set; }

    [Column("in_above_margin")]
    public int InAboveMargin { get; set; }

    [Column("out_ahead_margin")]
    public int OutAheadMargin { get; set; }

    [Column("out_above_margin")]
    public int OutAboveMargin { get; set; }

    [Column("duration")]
    public int Duration { get; set; }

    [Column("in_required")]
    public short InRequired { get; set; }

    [Column("out_required")]
    public short OutRequired { get; set; }

    [Column("allow_late")]
    public int AllowLate { get; set; }

    [Column("allow_leave_early")]
    public int AllowLeaveEarly { get; set; }

    [Column("work_day")]
    public double WorkDay { get; set; }

    [Column("multiple_punch")]
    public short MultiplePunch { get; set; }

    [Column("available_interval_type")]
    public short AvailableIntervalType { get; set; }

    [Column("available_interval")]
    public int AvailableInterval { get; set; }

    [Column("work_time_duration")]
    public int WorkTimeDuration { get; set; }

    [Column("func_key")]
    public short FuncKey { get; set; }

    [Column("work_type")]
    public short WorkType { get; set; }

    [Column("day_change", TypeName = "datetime")]
    public DateTime DayChange { get; set; }

    [Column("early_in")]
    public short EarlyIn { get; set; }

    [Column("late_out")]
    public short LateOut { get; set; }

    [Column("min_early_in")]
    public int MinEarlyIn { get; set; }

    [Column("min_late_out")]
    public int MinLateOut { get; set; }

    [Column("overtime_lv")]
    public short OvertimeLv { get; set; }

    [Column("overtime_lv1")]
    public short OvertimeLv1 { get; set; }

    [Column("overtime_lv2")]
    public short OvertimeLv2 { get; set; }

    [Column("overtime_lv3")]
    public short OvertimeLv3 { get; set; }

    [InverseProperty("Timeinterval")]
    public virtual ICollection<AttChangeschedule> AttChangeschedules { get; set; } = new List<AttChangeschedule>();

    [InverseProperty("Timetable")]
    public virtual ICollection<AttPayloadbase> AttPayloadbases { get; set; } = new List<AttPayloadbase>();

    [InverseProperty("TimeInterval")]
    public virtual ICollection<AttShiftdetail> AttShiftdetails { get; set; } = new List<AttShiftdetail>();

    [InverseProperty("Timeinterval")]
    public virtual ICollection<AttTimeintervalBreakTime> AttTimeintervalBreakTimes { get; set; } = new List<AttTimeintervalBreakTime>();
}
