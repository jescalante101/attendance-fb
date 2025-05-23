using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("django_content_type")]
[Index("AppLabel", "Model", Name = "django_content_type_app_label_model_76bd3d3b_uniq", IsUnique = true)]
public partial class DjangoContentType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("app_label")]
    [StringLength(100)]
    public string AppLabel { get; set; } = null!;

    [Column("model")]
    [StringLength(100)]
    public string Model { get; set; } = null!;

    [InverseProperty("ContentType")]
    public virtual ICollection<AuthPermission> AuthPermissions { get; set; } = new List<AuthPermission>();

    [InverseProperty("ContentType")]
    public virtual ICollection<BaseAdminlog> BaseAdminlogs { get; set; } = new List<BaseAdminlog>();

    [InverseProperty("ContentType")]
    public virtual ICollection<BaseBookmark> BaseBookmarks { get; set; } = new List<BaseBookmark>();

    [InverseProperty("ContentType")]
    public virtual ICollection<DjangoAdminLog> DjangoAdminLogs { get; set; } = new List<DjangoAdminLog>();

    [InverseProperty("ContentType")]
    public virtual ICollection<GuardianGroupobjectpermission> GuardianGroupobjectpermissions { get; set; } = new List<GuardianGroupobjectpermission>();

    [InverseProperty("ContentType")]
    public virtual ICollection<GuardianUserobjectpermission> GuardianUserobjectpermissions { get; set; } = new List<GuardianUserobjectpermission>();

    [InverseProperty("ContentType")]
    public virtual ICollection<WorkflowWorkflowengine> WorkflowWorkflowengines { get; set; } = new List<WorkflowWorkflowengine>();
}
