using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_payloadmulpunchset")]
[Index("EmpId", Name = "att_payloadmulpunchset_emp_id_f47610c8")]
[Index("TimetableId", Name = "att_payloadmulpunchset_timetable_id_9a439a09")]
public partial class AttPayloadmulpunchset
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("att_date", TypeName = "datetime")]
    public DateTime AttDate { get; set; }

    [Column("weekday")]
    public short? Weekday { get; set; }

    [Column("data_index")]
    public short DataIndex { get; set; }

    [Column("clock_in", TypeName = "datetime")]
    public DateTime? ClockIn { get; set; }

    [Column("in_id")]
    public int? InId { get; set; }

    [Column("clock_out", TypeName = "datetime")]
    public DateTime? ClockOut { get; set; }

    [Column("out_id")]
    public int? OutId { get; set; }

    [Column("total_time")]
    public int? TotalTime { get; set; }

    [Column("worked_time")]
    public int? WorkedTime { get; set; }

    [Column("data_type")]
    public short DataType { get; set; }

    [Column("emp_id")]
    public int EmpId { get; set; }

    [Column("timetable_id")]
    public int? TimetableId { get; set; }

    [ForeignKey("EmpId")]
    [InverseProperty("AttPayloadmulpunchsets")]
    public virtual PersonnelEmployee Emp { get; set; } = null!;
}
