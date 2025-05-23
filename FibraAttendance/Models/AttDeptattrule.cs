using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_deptattrule")]
[Index("DepartmentId", Name = "att_deptattrule_department_id_f333c8f0")]
public partial class AttDeptattrule
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("alias")]
    [StringLength(50)]
    public string Alias { get; set; } = null!;

    [Column("rule")]
    public string? Rule { get; set; }

    [Column("department_id")]
    public int DepartmentId { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("AttDeptattrules")]
    public virtual PersonnelDepartment Department { get; set; } = null!;
}
