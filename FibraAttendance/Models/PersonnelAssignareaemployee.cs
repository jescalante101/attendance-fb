using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("personnel_assignareaemployee")]
[Index("AreaId", Name = "personnel_assignareaemployee_area_id_6f049d6a")]
[Index("EmployeeId", Name = "personnel_assignareaemployee_employee_id_a3d4dd25")]
public partial class PersonnelAssignareaemployee
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("assigned_time", TypeName = "datetime")]
    public DateTime AssignedTime { get; set; }

    [Column("area_id")]
    public int AreaId { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [ForeignKey("AreaId")]
    [InverseProperty("PersonnelAssignareaemployees")]
    public virtual PersonnelArea Area { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("PersonnelAssignareaemployees")]
    public virtual PersonnelEmployee Employee { get; set; } = null!;
}
