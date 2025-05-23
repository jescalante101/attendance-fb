using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("guardian_userobjectpermission")]
[Index("ContentTypeId", Name = "guardian_userobjectpermission_content_type_id_2e892405")]
[Index("PermissionId", Name = "guardian_userobjectpermission_permission_id_71807bfc")]
[Index("UserId", Name = "guardian_userobjectpermission_user_id_d5c1e964")]
[Index("UserId", "PermissionId", "ObjectPk", Name = "guardian_userobjectpermission_user_id_permission_id_object_pk_b0b3d2fc_uniq", IsUnique = true)]
public partial class GuardianUserobjectpermission
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("object_pk")]
    [StringLength(255)]
    public string ObjectPk { get; set; } = null!;

    [Column("content_type_id")]
    public int ContentTypeId { get; set; }

    [Column("permission_id")]
    public int PermissionId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [ForeignKey("ContentTypeId")]
    [InverseProperty("GuardianUserobjectpermissions")]
    public virtual DjangoContentType ContentType { get; set; } = null!;

    [ForeignKey("PermissionId")]
    [InverseProperty("GuardianUserobjectpermissions")]
    public virtual AuthPermission Permission { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("GuardianUserobjectpermissions")]
    public virtual AuthUser User { get; set; } = null!;
}
