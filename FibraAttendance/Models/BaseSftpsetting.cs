using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("base_sftpsetting")]
[Index("UserName", "Host", Name = "base_sftpsetting_user_name_host_f95e6bd9_uniq", IsUnique = true)]
public partial class BaseSftpsetting
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("host")]
    [StringLength(39)]
    public string Host { get; set; } = null!;

    [Column("port")]
    public int Port { get; set; }

    [Column("auth_method")]
    public int AuthMethod { get; set; }

    [Column("user_name")]
    [StringLength(30)]
    public string UserName { get; set; } = null!;

    [Column("user_password")]
    [StringLength(128)]
    public string? UserPassword { get; set; }

    [Column("user_key")]
    public string? UserKey { get; set; }

    [Column("key_password")]
    [StringLength(128)]
    public string? KeyPassword { get; set; }
}
