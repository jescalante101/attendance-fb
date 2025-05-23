using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_shiftdetail")]
[Index("ShiftId", Name = "att_shiftdetail_shift_id_7d694501")]
[Index("TimeIntervalId", Name = "att_shiftdetail_time_interval_id_777dde8f")]
public partial class AttShiftdetail
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("in_time", TypeName = "datetime")]
    public DateTime InTime { get; set; }

    [Column("out_time", TypeName = "datetime")]
    public DateTime OutTime { get; set; }

    [Column("day_index")]
    public int DayIndex { get; set; }

    [Column("shift_id")]
    public int ShiftId { get; set; }

    [Column("time_interval_id")]
    public int TimeIntervalId { get; set; }

    [ForeignKey("ShiftId")]
    [InverseProperty("AttShiftdetails")]
    public virtual AttAttshift Shift { get; set; } = null!;

    [ForeignKey("TimeIntervalId")]
    [InverseProperty("AttShiftdetails")]
    public virtual AttTimeinterval TimeInterval { get; set; } = null!;
}
