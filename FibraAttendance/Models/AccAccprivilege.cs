using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("acc_accprivilege")]
[Index("AreaId", Name = "acc_accprivilege_area_id_2123ff6f")]
[Index("AreaId", "EmployeeId", "GroupId", Name = "acc_accprivilege_area_id_employee_id_group_id_f3b297d8_uniq", IsUnique = true)]
[Index("EmployeeId", Name = "acc_accprivilege_employee_id_5fc55f95")]
[Index("GroupId", Name = "acc_accprivilege_group_id_c5ed7003")]
public partial class AccAccprivilege
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

    [Column("is_group_timezone")]
    public short IsGroupTimezone { get; set; }

    [Column("timezone1")]
    public int? Timezone1 { get; set; }

    [Column("timezone2")]
    public int? Timezone2 { get; set; }

    [Column("timezone3")]
    public int? Timezone3 { get; set; }

    [Column("is_group_verifycode")]
    public short IsGroupVerifycode { get; set; }

    [Column("verify_mode")]
    public int? VerifyMode { get; set; }

    [Column("update_time", TypeName = "datetime")]
    public DateTime? UpdateTime { get; set; }

    [Column("area_id")]
    public int AreaId { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Column("group_id")]
    public int GroupId { get; set; }

    [ForeignKey("AreaId")]
    [InverseProperty("AccAccprivileges")]
    public virtual PersonnelArea Area { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("AccAccprivileges")]
    public virtual PersonnelEmployee Employee { get; set; } = null!;

    [ForeignKey("GroupId")]
    [InverseProperty("AccAccprivileges")]
    public virtual AccAccgroup Group { get; set; } = null!;
}
