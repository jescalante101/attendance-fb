using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("mobile_appnotification")]
[Index("ReceiverId", Name = "mobile_appnotification_receiver_id_90c4a355")]
public partial class MobileAppnotification
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("sender")]
    [StringLength(50)]
    public string? Sender { get; set; }

    [Column("system_sender")]
    [StringLength(50)]
    public string? SystemSender { get; set; }

    [Column("category")]
    public short Category { get; set; }

    [Column("sub_category")]
    public int? SubCategory { get; set; }

    [Column("content")]
    public string? Content { get; set; }

    [Column("source")]
    public int? Source { get; set; }

    [Column("notification_time", TypeName = "datetime")]
    public DateTime NotificationTime { get; set; }

    [Column("read_status")]
    public short ReadStatus { get; set; }

    [Column("read_time", TypeName = "datetime")]
    public DateTime? ReadTime { get; set; }

    [Column("receiver_id")]
    public int ReceiverId { get; set; }

    [ForeignKey("ReceiverId")]
    [InverseProperty("MobileAppnotifications")]
    public virtual PersonnelEmployee Receiver { get; set; } = null!;
}
