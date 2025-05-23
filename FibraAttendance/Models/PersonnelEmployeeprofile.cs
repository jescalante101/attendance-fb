using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("personnel_employeeprofile")]
[Index("EmpId", Name = "UQ__personne__1299A86007C767E5", IsUnique = true)]
public partial class PersonnelEmployeeprofile
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("column_order")]
    public string ColumnOrder { get; set; } = null!;

    [Column("preferences")]
    public string Preferences { get; set; } = null!;

    [Column("emp_id")]
    public int EmpId { get; set; }

    [ForeignKey("EmpId")]
    [InverseProperty("PersonnelEmployeeprofile")]
    public virtual PersonnelEmployee Emp { get; set; } = null!;
}
