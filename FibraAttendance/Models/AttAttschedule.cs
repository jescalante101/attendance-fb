using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_attschedule")]
[Index("EmployeeId", Name = "att_attschedule_employee_id_caa61686")]
[Index("ShiftId", Name = "att_attschedule_shift_id_13d2db9a")]
public partial class AttAttschedule
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("start_date", TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column("end_date", TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Column("shift_id")]
    public int ShiftId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("AttAttschedules")]
    public virtual PersonnelEmployee Employee { get; set; } = null!;

    [ForeignKey("ShiftId")]
    [InverseProperty("AttAttschedules")]
    public virtual AttAttshift Shift { get; set; } = null!;
}
