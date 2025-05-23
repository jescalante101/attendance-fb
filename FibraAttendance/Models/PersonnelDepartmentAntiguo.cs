using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Keyless]
[Table("personnel_department_ANTIGUO")]
public partial class PersonnelDepartmentAntiguo
{
    [Column("id")]
    public int Id { get; set; }

    [Column("dept_code")]
    [StringLength(50)]
    public string DeptCode { get; set; } = null!;

    [Column("dept_name")]
    [StringLength(100)]
    public string DeptName { get; set; } = null!;

    [Column("is_default")]
    public bool IsDefault { get; set; }

    [Column("company_id")]
    public int? CompanyId { get; set; }

    [Column("parent_dept_id")]
    public int? ParentDeptId { get; set; }
}
