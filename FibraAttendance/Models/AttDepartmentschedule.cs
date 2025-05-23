using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_departmentschedule")]
[Index("DepartmentId", Name = "att_departmentschedule_department_id_c68fca3d")]
[Index("ShiftId", Name = "att_departmentschedule_shift_id_c37d5ade")]
public partial class AttDepartmentschedule
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("create_time", TypeName = "datetime")]
    public DateTime? CreateTime { get; set; }

    [Column("create_user")]
    [StringLength(150)]
    public string? CreateUser { get; set; }

    [Column("change_time", TypeName = "datetime")]
    public DateTime? ChangeTime { get; set; }

    [Column("change_user")]
    [StringLength(150)]
    public string? ChangeUser { get; set; }

    [Column("status")]
    public short Status { get; set; }

    [Column("start_date", TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column("end_date", TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    [Column("department_id")]
    public int DepartmentId { get; set; }

    [Column("shift_id")]
    public int ShiftId { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("AttDepartmentschedules")]
    public virtual PersonnelDepartment Department { get; set; } = null!;

    [ForeignKey("ShiftId")]
    [InverseProperty("AttDepartmentschedules")]
    public virtual AttAttshift Shift { get; set; } = null!;
}
