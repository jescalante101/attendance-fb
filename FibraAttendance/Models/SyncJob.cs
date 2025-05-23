using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("sync_job")]
[Index("JobCode", "JobName", Name = "sync_job_job_code_job_name_4ec5619e_uniq", IsUnique = true)]
public partial class SyncJob
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("job_code")]
    [StringLength(50)]
    public string JobCode { get; set; } = null!;

    [Column("job_name")]
    [StringLength(100)]
    public string JobName { get; set; } = null!;

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
