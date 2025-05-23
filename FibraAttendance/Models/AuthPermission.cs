using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("auth_permission")]
[Index("ContentTypeId", Name = "auth_permission_content_type_id_2f476e4b")]
[Index("ContentTypeId", "Codename", Name = "auth_permission_content_type_id_codename_01ab375a_uniq", IsUnique = true)]
public partial class AuthPermission
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("content_type_id")]
    public int ContentTypeId { get; set; }

    [Column("codename")]
    [StringLength(100)]
    public string Codename { get; set; } = null!;

    [InverseProperty("Permission")]
    public virtual ICollection<AuthGroupPermission> AuthGroupPermissions { get; set; } = new List<AuthGroupPermission>();

    [InverseProperty("Permission")]
    public virtual ICollection<AuthUserUserPermission> AuthUserUserPermissions { get; set; } = new List<AuthUserUserPermission>();

    [ForeignKey("ContentTypeId")]
    [InverseProperty("AuthPermissions")]
    public virtual DjangoContentType ContentType { get; set; } = null!;

    [InverseProperty("Permission")]
    public virtual ICollection<GuardianGroupobjectpermission> GuardianGroupobjectpermissions { get; set; } = new List<GuardianGroupobjectpermission>();

    [InverseProperty("Permission")]
    public virtual ICollection<GuardianUserobjectpermission> GuardianUserobjectpermissions { get; set; } = new List<GuardianUserobjectpermission>();
}
