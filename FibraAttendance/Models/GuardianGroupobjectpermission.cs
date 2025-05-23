using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("guardian_groupobjectpermission")]
[Index("ContentTypeId", Name = "guardian_groupobjectpermission_content_type_id_7ade36b8")]
[Index("GroupId", Name = "guardian_groupobjectpermission_group_id_4bbbfb62")]
[Index("GroupId", "PermissionId", "ObjectPk", Name = "guardian_groupobjectpermission_group_id_permission_id_object_pk_3f189f7c_uniq", IsUnique = true)]
[Index("PermissionId", Name = "guardian_groupobjectpermission_permission_id_36572738")]
public partial class GuardianGroupobjectpermission
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("object_pk")]
    [StringLength(255)]
    public string ObjectPk { get; set; } = null!;

    [Column("content_type_id")]
    public int ContentTypeId { get; set; }

    [Column("group_id")]
    public int GroupId { get; set; }

    [Column("permission_id")]
    public int PermissionId { get; set; }

    [ForeignKey("ContentTypeId")]
    [InverseProperty("GuardianGroupobjectpermissions")]
    public virtual DjangoContentType ContentType { get; set; } = null!;

    [ForeignKey("GroupId")]
    [InverseProperty("GuardianGroupobjectpermissions")]
    public virtual AuthGroup Group { get; set; } = null!;

    [ForeignKey("PermissionId")]
    [InverseProperty("GuardianGroupobjectpermissions")]
    public virtual AuthPermission Permission { get; set; } = null!;
}
