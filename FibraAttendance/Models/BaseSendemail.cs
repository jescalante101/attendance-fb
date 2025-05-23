using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("base_sendemail")]
public partial class BaseSendemail
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("purpose")]
    public int Purpose { get; set; }

    [Column("email_to")]
    public string EmailTo { get; set; } = null!;

    [Column("email_cc")]
    public string? EmailCc { get; set; }

    [Column("email_bcc")]
    public string? EmailBcc { get; set; }

    [Column("email_subject")]
    [StringLength(40)]
    public string EmailSubject { get; set; } = null!;

    [Column("email_content")]
    public string? EmailContent { get; set; }

    [Column("send_time", TypeName = "datetime")]
    public DateTime? SendTime { get; set; }

    [Column("send_status")]
    public short? SendStatus { get; set; }
}
