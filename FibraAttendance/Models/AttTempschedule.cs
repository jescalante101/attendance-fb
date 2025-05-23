using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_tempschedule")]
[Index("EmployeeId", Name = "att_tempschedule_employee_id_b89c7e54")]
[Index("TimeIntervalId", Name = "att_tempschedule_time_interval_id_08dd8eb3")]
public partial class AttTempschedule
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("start_time", TypeName = "datetime")]
    public DateTime StartTime { get; set; }

    [Column("end_time", TypeName = "datetime")]
    public DateTime EndTime { get; set; }

    [Column("rule_flag")]
    public short RuleFlag { get; set; }

    [Column("work_type")]
    public short WorkType { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Column("time_interval_id")]
    public int? TimeIntervalId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("AttTempschedules")]
    public virtual PersonnelEmployee Employee { get; set; } = null!;
}
