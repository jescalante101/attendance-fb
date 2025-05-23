using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_payloadexception")]
[Index("ItemId", Name = "att_payloadexception_item_id_a08bfe48")]
[Index("SkdId", Name = "att_payloadexception_skd_id_b2e9ecaa")]
public partial class AttPayloadexception
{
    [Key]
    [Column("uuid")]
    [StringLength(36)]
    public string Uuid { get; set; } = null!;

    [Column("start_time", TypeName = "datetime")]
    public DateTime StartTime { get; set; }

    [Column("end_time", TypeName = "datetime")]
    public DateTime EndTime { get; set; }

    [Column("duration")]
    public int? Duration { get; set; }

    [Column("days")]
    public double? Days { get; set; }

    [Column("data_type")]
    public short DataType { get; set; }

    [Column("description")]
    [StringLength(50)]
    public string? Description { get; set; }

    [Column("item_id")]
    public int? ItemId { get; set; }

    [Column("skd_id")]
    [StringLength(36)]
    public string? SkdId { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("AttPayloadexceptions")]
    public virtual AttLeave? Item { get; set; }
}
