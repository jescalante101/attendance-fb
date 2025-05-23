using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_attshift")]
public partial class AttAttshift
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("alias")]
    [StringLength(50)]
    public string Alias { get; set; } = null!;

    [Column("cycle_unit")]
    public short CycleUnit { get; set; }

    [Column("shift_cycle")]
    public int ShiftCycle { get; set; }

    [Column("work_weekend")]
    public bool WorkWeekend { get; set; }

    [Column("weekend_type")]
    public short WeekendType { get; set; }

    [Column("work_day_off")]
    public bool WorkDayOff { get; set; }

    [Column("day_off_type")]
    public short DayOffType { get; set; }

    [Column("auto_shift")]
    public bool AutoShift { get; set; }

    [InverseProperty("Shift")]
    public virtual ICollection<AttAttschedule> AttAttschedules { get; set; } = new List<AttAttschedule>();

    [InverseProperty("Shift")]
    public virtual ICollection<AttDepartmentschedule> AttDepartmentschedules { get; set; } = new List<AttDepartmentschedule>();

    [InverseProperty("Shift")]
    public virtual ICollection<AttShiftdetail> AttShiftdetails { get; set; } = new List<AttShiftdetail>();
}
