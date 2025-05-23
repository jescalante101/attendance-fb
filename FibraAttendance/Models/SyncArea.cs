using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("sync_area")]
[Index("AreaCode", "AreaName", Name = "sync_area_area_code_area_name_200046d1_uniq", IsUnique = true)]
public partial class SyncArea
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("area_code")]
    [StringLength(30)]
    public string AreaCode { get; set; } = null!;

    [Column("area_name")]
    [StringLength(30)]
    public string AreaName { get; set; } = null!;

    [Column("post_time", TypeName = "datetime")]
    public DateTime? PostTime { get; set; }

    [Column("flag")]
    public short Flag { get; set; }

    [Column("update_time", TypeName = "datetime")]
    public DateTime? UpdateTime { get; set; }

    [Column("sync_ret")]
    [StringLength(200)]
    public string? SyncRet { get; set; }
}
