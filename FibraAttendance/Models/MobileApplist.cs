using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("mobile_applist")]
public partial class MobileApplist
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("username")]
    [StringLength(50)]
    public string Username { get; set; } = null!;

    [Column("login_time", TypeName = "datetime")]
    public DateTime LoginTime { get; set; }

    [Column("last_active", TypeName = "datetime")]
    public DateTime LastActive { get; set; }

    [Column("token")]
    [StringLength(100)]
    public string Token { get; set; } = null!;

    [Column("device_token")]
    public string DeviceToken { get; set; } = null!;

    [Column("client_id")]
    [StringLength(100)]
    public string ClientId { get; set; } = null!;

    [Column("client_category")]
    public short ClientCategory { get; set; }

    [Column("active")]
    public short? Active { get; set; }

    [Column("enable")]
    public short? Enable { get; set; }
}
