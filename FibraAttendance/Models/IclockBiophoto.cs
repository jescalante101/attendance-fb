using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("iclock_biophoto")]
[Index("EmployeeId", Name = "iclock_biophoto_employee_id_3dba5819")]
public partial class IclockBiophoto
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

    [Column("first_name")]
    [StringLength(25)]
    public string? FirstName { get; set; }

    [Column("last_name")]
    [StringLength(25)]
    public string? LastName { get; set; }

    [Column("email")]
    [StringLength(254)]
    public string? Email { get; set; }

    [Column("enroll_sn")]
    [StringLength(50)]
    public string? EnrollSn { get; set; }

    [Column("register_photo")]
    [StringLength(100)]
    public string RegisterPhoto { get; set; } = null!;

    [Column("register_time", TypeName = "datetime")]
    public DateTime RegisterTime { get; set; }

    [Column("approval_photo")]
    [StringLength(100)]
    public string? ApprovalPhoto { get; set; }

    [Column("approval_state")]
    public short ApprovalState { get; set; }

    [Column("approval_time", TypeName = "datetime")]
    public DateTime? ApprovalTime { get; set; }

    [Column("remark")]
    [StringLength(100)]
    public string? Remark { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("IclockBiophotos")]
    public virtual PersonnelEmployee Employee { get; set; } = null!;
}
