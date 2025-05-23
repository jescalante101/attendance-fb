using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("auth_user_auth_dept")]
[Index("DepartmentId", Name = "auth_user_auth_dept_department_id_5866c514")]
[Index("MyuserId", Name = "auth_user_auth_dept_myuser_id_18a51b27")]
[Index("MyuserId", "DepartmentId", Name = "auth_user_auth_dept_myuser_id_department_id_61d83386_uniq", IsUnique = true)]
public partial class AuthUserAuthDept
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("myuser_id")]
    public int MyuserId { get; set; }

    [Column("department_id")]
    public int DepartmentId { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("AuthUserAuthDepts")]
    public virtual PersonnelDepartment Department { get; set; } = null!;

    [ForeignKey("MyuserId")]
    [InverseProperty("AuthUserAuthDepts")]
    public virtual AuthUser Myuser { get; set; } = null!;
}
