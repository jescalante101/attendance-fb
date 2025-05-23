using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("base_dbbackuplog")]
public partial class BaseDbbackuplog
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("create_time", TypeName = "datetime")]
    public DateTime? CreateTime { get; set; }

    [Column("create_user")]
    [StringLength(150)]
    public string? CreateUser { get; set; }

    [Column("change_time", TypeName = "datetime")]
    public DateTime? ChangeTime { get; set; }

    [Column("change_user")]
    [StringLength(150)]
    public string? ChangeUser { get; set; }

    [Column("status")]
    public short Status { get; set; }

    [Column("db_type")]
    [StringLength(50)]
    public string DbType { get; set; } = null!;

    [Column("db_name")]
    [StringLength(50)]
    public string DbName { get; set; } = null!;

    [Column("operator")]
    [StringLength(50)]
    public string? Operator { get; set; }

    [Column("backup_file")]
    [StringLength(100)]
    public string BackupFile { get; set; } = null!;

    [Column("backup_time", TypeName = "datetime")]
    public DateTime BackupTime { get; set; }

    [Column("backup_status")]
    public short BackupStatus { get; set; }

    [Column("remark")]
    public string? Remark { get; set; }
}
