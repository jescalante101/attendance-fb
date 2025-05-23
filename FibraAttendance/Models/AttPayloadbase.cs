using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_payloadbase")]
[Index("BreakTimeId", Name = "UQ__att_payl__3C490B1222801DA4", IsUnique = true)]
[Index("OvertimeId", Name = "UQ__att_payl__B846E81056C6C567", IsUnique = true)]
[Index("EmpId", Name = "att_payloadbase_emp_id_2c0f6a7b")]
[Index("TimetableId", Name = "att_payloadbase_timetable_id_a389e3d8")]
[Index("TransInId", Name = "att_payloadbase_trans_in_id_3b8fd648")]
[Index("TransOutId", Name = "att_payloadbase_trans_out_id_ec63bbcc")]
public partial class AttPayloadbase
{
    [Key]
    [Column("uuid")]
    [StringLength(36)]
    public string Uuid { get; set; } = null!;

    [Column("att_date", TypeName = "datetime")]
    public DateTime? AttDate { get; set; }

    [Column("weekday")]
    public short? Weekday { get; set; }

    [Column("check_in", TypeName = "datetime")]
    public DateTime? CheckIn { get; set; }

    [Column("check_out", TypeName = "datetime")]
    public DateTime? CheckOut { get; set; }

    [Column("duration")]
    public int? Duration { get; set; }

    [Column("duty_duration")]
    public int? DutyDuration { get; set; }

    [Column("work_day")]
    public double WorkDay { get; set; }

    [Column("clock_in", TypeName = "datetime")]
    public DateTime? ClockIn { get; set; }

    [Column("clock_out", TypeName = "datetime")]
    public DateTime? ClockOut { get; set; }

    [Column("total_time")]
    public int? TotalTime { get; set; }

    [Column("duty_worked")]
    public int? DutyWorked { get; set; }

    [Column("actual_worked")]
    public int? ActualWorked { get; set; }

    [Column("unscheduled")]
    public int? Unscheduled { get; set; }

    [Column("remaining")]
    public int? Remaining { get; set; }

    [Column("total_worked")]
    public int? TotalWorked { get; set; }

    [Column("late")]
    public int? Late { get; set; }

    [Column("early_leave")]
    public int? EarlyLeave { get; set; }

    [Column("short")]
    public int? Short { get; set; }

    [Column("absent")]
    public int? Absent { get; set; }

    [Column("leave")]
    public int? Leave { get; set; }

    [Column("exception")]
    [StringLength(50)]
    public string? Exception { get; set; }

    [Column("day_off")]
    public short DayOff { get; set; }

    [Column("break_time_id")]
    [StringLength(36)]
    public string? BreakTimeId { get; set; }

    [Column("emp_id")]
    public int EmpId { get; set; }

    [Column("overtime_id")]
    [StringLength(36)]
    public string? OvertimeId { get; set; }

    [Column("timetable_id")]
    public int? TimetableId { get; set; }

    [Column("trans_in_id")]
    public int? TransInId { get; set; }

    [Column("trans_out_id")]
    public int? TransOutId { get; set; }

    [ForeignKey("EmpId")]
    [InverseProperty("AttPayloadbases")]
    public virtual PersonnelEmployee Emp { get; set; } = null!;

    [ForeignKey("TimetableId")]
    [InverseProperty("AttPayloadbases")]
    public virtual AttTimeinterval? Timetable { get; set; }

    [ForeignKey("TransInId")]
    [InverseProperty("AttPayloadbaseTransIns")]
    public virtual IclockTransaction? TransIn { get; set; }

    [ForeignKey("TransOutId")]
    [InverseProperty("AttPayloadbaseTransOuts")]
    public virtual IclockTransaction? TransOut { get; set; }
}
