using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("base_adminlog")]
[Index("ContentTypeId", Name = "base_adminlog_content_type_id_3e553c30")]
[Index("UserId", Name = "base_adminlog_user_id_ecf659f8")]
public partial class BaseAdminlog
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("action")]
    [StringLength(50)]
    public string Action { get; set; } = null!;

    [Column("targets")]
    public string? Targets { get; set; }

    [Column("targets_repr")]
    public string? TargetsRepr { get; set; }

    [Column("action_status")]
    public short ActionStatus { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("ip_address")]
    [StringLength(39)]
    public string? IpAddress { get; set; }

    [Column("can_routable")]
    public bool CanRoutable { get; set; }

    [Column("op_time", TypeName = "datetime")]
    public DateTime OpTime { get; set; }

    [Column("content_type_id")]
    public int? ContentTypeId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [ForeignKey("ContentTypeId")]
    [InverseProperty("BaseAdminlogs")]
    public virtual DjangoContentType? ContentType { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("BaseAdminlogs")]
    public virtual AuthUser User { get; set; } = null!;
}
