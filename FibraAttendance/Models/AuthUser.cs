using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("auth_user")]
[Index("Username", Name = "UQ__auth_use__F3DBC572CEC8DFE2", IsUnique = true)]
public partial class AuthUser
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("username")]
    [StringLength(30)]
    public string Username { get; set; } = null!;

    [Column("password")]
    [StringLength(128)]
    public string Password { get; set; } = null!;

    [Column("first_name")]
    [StringLength(30)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(30)]
    public string LastName { get; set; } = null!;

    [Column("emp_pin")]
    [StringLength(30)]
    public string? EmpPin { get; set; }

    [Column("email")]
    [StringLength(254)]
    public string Email { get; set; } = null!;

    [Column("tele_phone")]
    [StringLength(30)]
    public string? TelePhone { get; set; }

    [Column("auth_time_dept")]
    public int? AuthTimeDept { get; set; }

    [Column("login_id")]
    public int? LoginId { get; set; }

    [Column("login_type")]
    public int? LoginType { get; set; }

    [Column("login_count")]
    public int? LoginCount { get; set; }

    [Column("is_staff")]
    public bool IsStaff { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; }

    [Column("is_superuser")]
    public bool IsSuperuser { get; set; }

    [Column("is_public")]
    public bool IsPublic { get; set; }

    [Column("can_manage_all_dept")]
    public bool CanManageAllDept { get; set; }

    [Column("del_flag")]
    public int? DelFlag { get; set; }

    [Column("date_joined", TypeName = "datetime")]
    public DateTime DateJoined { get; set; }

    [Column("last_login", TypeName = "datetime")]
    public DateTime? LastLogin { get; set; }

    [InverseProperty("Myuser")]
    public virtual ICollection<AuthUserAuthArea> AuthUserAuthAreas { get; set; } = new List<AuthUserAuthArea>();

    [InverseProperty("Myuser")]
    public virtual ICollection<AuthUserAuthDept> AuthUserAuthDepts { get; set; } = new List<AuthUserAuthDept>();

    [InverseProperty("Myuser")]
    public virtual ICollection<AuthUserGroup> AuthUserGroups { get; set; } = new List<AuthUserGroup>();

    [InverseProperty("User")]
    public virtual AuthUserProfile? AuthUserProfile { get; set; }

    [InverseProperty("Myuser")]
    public virtual ICollection<AuthUserUserPermission> AuthUserUserPermissions { get; set; } = new List<AuthUserUserPermission>();

    [InverseProperty("User")]
    public virtual AuthtokenToken? AuthtokenToken { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<BaseAdminlog> BaseAdminlogs { get; set; } = new List<BaseAdminlog>();

    [InverseProperty("User")]
    public virtual ICollection<BaseBookmark> BaseBookmarks { get; set; } = new List<BaseBookmark>();

    [InverseProperty("User")]
    public virtual ICollection<DjangoAdminLog> DjangoAdminLogs { get; set; } = new List<DjangoAdminLog>();

    [InverseProperty("User")]
    public virtual ICollection<GuardianUserobjectpermission> GuardianUserobjectpermissions { get; set; } = new List<GuardianUserobjectpermission>();

    [InverseProperty("ApproverAdmin")]
    public virtual ICollection<WorkflowNodeinstance> WorkflowNodeinstances { get; set; } = new List<WorkflowNodeinstance>();
}
