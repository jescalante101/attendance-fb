using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("personnel_department")]
[Index("DeptCode", Name = "UQ__personne__799C94D59C56B0B3", IsUnique = true)]
[Index("CompanyId", Name = "personnel_department_company_id_00867fd8")]
[Index("ParentDeptId", Name = "personnel_department_parent_dept_id_d0b44024")]
public partial class PersonnelDepartment
{
    [Key]
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

    [InverseProperty("Department")]
    public virtual ICollection<AttDepartmentschedule> AttDepartmentschedules { get; set; } = new List<AttDepartmentschedule>();

    [InverseProperty("Department")]
    public virtual ICollection<AttDeptattrule> AttDeptattrules { get; set; } = new List<AttDeptattrule>();

    [InverseProperty("Department")]
    public virtual ICollection<AttHoliday> AttHolidays { get; set; } = new List<AttHoliday>();

    [InverseProperty("Department")]
    public virtual ICollection<AuthUserAuthDept> AuthUserAuthDepts { get; set; } = new List<AuthUserAuthDept>();

    [InverseProperty("LineNotifyDept")]
    public virtual ICollection<BaseLinenotifysetting> BaseLinenotifysettings { get; set; } = new List<BaseLinenotifysetting>();

    [ForeignKey("CompanyId")]
    [InverseProperty("PersonnelDepartments")]
    public virtual PersonnelCompany? Company { get; set; }

    [InverseProperty("ParentDept")]
    public virtual ICollection<PersonnelDepartment> InverseParentDept { get; set; } = new List<PersonnelDepartment>();

    [InverseProperty("Department")]
    public virtual ICollection<MobileGpsfordepartment> MobileGpsfordepartments { get; set; } = new List<MobileGpsfordepartment>();

    [ForeignKey("ParentDeptId")]
    [InverseProperty("InverseParentDept")]
    public virtual PersonnelDepartment? ParentDept { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<PersonnelEmployee> PersonnelEmployees { get; set; } = new List<PersonnelEmployee>();

    [InverseProperty("Departments")]
    public virtual ICollection<WorkflowNodeinstance> WorkflowNodeinstances { get; set; } = new List<WorkflowNodeinstance>();

    [InverseProperty("Departments")]
    public virtual ICollection<WorkflowWorkflowengine> WorkflowWorkflowengines { get; set; } = new List<WorkflowWorkflowengine>();
}
