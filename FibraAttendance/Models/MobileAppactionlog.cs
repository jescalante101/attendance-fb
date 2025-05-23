using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("mobile_appactionlog")]
public partial class MobileAppactionlog
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user")]
    [StringLength(20)]
    public string User { get; set; } = null!;

    [Column("client")]
    [StringLength(50)]
    public string? Client { get; set; }

    [Column("action")]
    [StringLength(50)]
    public string? Action { get; set; }

    [Column("params")]
    public string? Params { get; set; }

    [Column("describe")]
    public string? Describe { get; set; }

    [Column("request_status")]
    public short RequestStatus { get; set; }

    [Column("action_time", TypeName = "datetime")]
    public DateTime ActionTime { get; set; }

    [Column("remote_ip")]
    [StringLength(20)]
    public string? RemoteIp { get; set; }
}
