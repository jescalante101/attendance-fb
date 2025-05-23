using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("sync_employee")]
[Index("EmpCode", Name = "sync_employee_emp_code_521bf06d_uniq", IsUnique = true)]
public partial class SyncEmployee
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("emp_code")]
    [StringLength(20)]
    public string EmpCode { get; set; } = null!;

    [Column("first_name")]
    [StringLength(25)]
    public string? FirstName { get; set; }

    [Column("last_name")]
    [StringLength(25)]
    public string? LastName { get; set; }

    [Column("dept_code")]
    [StringLength(50)]
    public string? DeptCode { get; set; }

    [Column("dept_name")]
    [StringLength(100)]
    public string? DeptName { get; set; }

    [Column("job_code")]
    [StringLength(50)]
    public string? JobCode { get; set; }

    [Column("job_name")]
    [StringLength(100)]
    public string? JobName { get; set; }

    [Column("area_code")]
    [StringLength(30)]
    public string? AreaCode { get; set; }

    [Column("area_name")]
    [StringLength(30)]
    public string? AreaName { get; set; }

    [Column("card_no")]
    [StringLength(20)]
    public string? CardNo { get; set; }

    [Column("multi_area")]
    public bool MultiArea { get; set; }

    [Column("hire_date", TypeName = "datetime")]
    public DateTime? HireDate { get; set; }

    [Column("gender")]
    [StringLength(2)]
    public string? Gender { get; set; }

    [Column("birthday", TypeName = "datetime")]
    public DateTime? Birthday { get; set; }

    [Column("email")]
    [StringLength(100)]
    public string? Email { get; set; }

    [Column("active_status")]
    public bool ActiveStatus { get; set; }

    [Column("post_time", TypeName = "datetime")]
    public DateTime? PostTime { get; set; }

    [Column("flag")]
    public short Flag { get; set; }

    [Column("update_time", TypeName = "datetime")]
    public DateTime? UpdateTime { get; set; }

    [Column("sync_ret")]
    [StringLength(200)]
    public string? SyncRet { get; set; }
}
