using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("celery_tasksetmeta")]
[Index("TasksetId", Name = "UQ__celery_t__45DBBA5BB70E954E", IsUnique = true)]
[Index("Hidden", Name = "celery_tasksetmeta_hidden_593cfc24")]
public partial class CeleryTasksetmetum
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("taskset_id")]
    [StringLength(255)]
    public string TasksetId { get; set; } = null!;

    [Column("result")]
    public string Result { get; set; } = null!;

    [Column("date_done", TypeName = "datetime")]
    public DateTime DateDone { get; set; }

    [Column("hidden")]
    public bool Hidden { get; set; }
}
