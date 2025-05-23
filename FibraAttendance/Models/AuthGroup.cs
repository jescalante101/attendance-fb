using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("auth_group")]
[Index("Name", Name = "UQ__auth_gro__72E12F1B33180C84", IsUnique = true)]
public partial class AuthGroup
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(80)]
    public string Name { get; set; } = null!;

    [InverseProperty("Group")]
    public virtual ICollection<AuthGroupPermission> AuthGroupPermissions { get; set; } = new List<AuthGroupPermission>();

    [InverseProperty("Group")]
    public virtual ICollection<AuthUserGroup> AuthUserGroups { get; set; } = new List<AuthUserGroup>();

    [InverseProperty("Group")]
    public virtual ICollection<GuardianGroupobjectpermission> GuardianGroupobjectpermissions { get; set; } = new List<GuardianGroupobjectpermission>();
}
