using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_timeinterval_break_time")]
[Index("BreaktimeId", Name = "att_timeinterval_break_time_breaktime_id_08462308")]
[Index("TimeintervalId", Name = "att_timeinterval_break_time_timeinterval_id_2287017e")]
[Index("TimeintervalId", "BreaktimeId", Name = "att_timeinterval_break_time_timeinterval_id_breaktime_id_6e1bfb4e_uniq", IsUnique = true)]
public partial class AttTimeintervalBreakTime
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("timeinterval_id")]
    public int TimeintervalId { get; set; }

    [Column("breaktime_id")]
    public int BreaktimeId { get; set; }

    [ForeignKey("BreaktimeId")]
    [InverseProperty("AttTimeintervalBreakTimes")]
    public virtual AttBreaktime Breaktime { get; set; } = null!;

    [ForeignKey("TimeintervalId")]
    [InverseProperty("AttTimeintervalBreakTimes")]
    public virtual AttTimeinterval Timeinterval { get; set; } = null!;
}
