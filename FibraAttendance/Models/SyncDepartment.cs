using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("sync_department")]
[Index("DeptCode", "DeptName", Name = "sync_department_dept_code_dept_name_93923213_uniq", IsUnique = true)]
public partial class SyncDepartment
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
