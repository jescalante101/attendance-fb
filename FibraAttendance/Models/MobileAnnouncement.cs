using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("mobile_announcement")]
[Index("ReceiverId", Name = "mobile_announcement_receiver_id_ddf2a860")]
public partial class MobileAnnouncement
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("subject")]
    [StringLength(100)]
    public string Subject { get; set; } = null!;

    [Column("content")]
    public string Content { get; set; } = null!;

    [Column("category")]
    public short Category { get; set; }

    [Column("sender")]
    [StringLength(50)]
    public string? Sender { get; set; }

    [Column("system_sender")]
    [StringLength(50)]
    public string? SystemSender { get; set; }

    [Column("create_time", TypeName = "datetime")]
    public DateTime? CreateTime { get; set; }

    [Column("receiver_id")]
    public int? ReceiverId { get; set; }

    [ForeignKey("ReceiverId")]
    [InverseProperty("MobileAnnouncements")]
    public virtual PersonnelEmployee? Receiver { get; set; }
}
