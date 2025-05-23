using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("personnel_employee_area")]
[Index("AreaId", Name = "personnel_employee_area_area_id_64c21925")]
[Index("EmployeeId", Name = "personnel_employee_area_employee_id_8e5cec21")]
[Index("EmployeeId", "AreaId", Name = "personnel_employee_area_employee_id_area_id_00b3d777_uniq", IsUnique = true)]
public partial class PersonnelEmployeeArea
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Column("area_id")]
    public int AreaId { get; set; }

    [ForeignKey("AreaId")]
    [InverseProperty("PersonnelEmployeeAreas")]
    public virtual PersonnelArea Area { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("PersonnelEmployeeAreas")]
    public virtual PersonnelEmployee Employee { get; set; } = null!;
}
