using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("auth_user_user_permissions")]
[Index("MyuserId", Name = "auth_user_user_permissions_myuser_id_679b1527")]
[Index("MyuserId", "PermissionId", Name = "auth_user_user_permissions_myuser_id_permission_id_a558717f_uniq", IsUnique = true)]
[Index("PermissionId", Name = "auth_user_user_permissions_permission_id_1fbb5f2c")]
public partial class AuthUserUserPermission
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("myuser_id")]
    public int MyuserId { get; set; }

    [Column("permission_id")]
    public int PermissionId { get; set; }

    [ForeignKey("MyuserId")]
    [InverseProperty("AuthUserUserPermissions")]
    public virtual AuthUser Myuser { get; set; } = null!;

    [ForeignKey("PermissionId")]
    [InverseProperty("AuthUserUserPermissions")]
    public virtual AuthPermission Permission { get; set; } = null!;
}
