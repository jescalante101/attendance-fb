using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("base_taskresultlog")]
public partial class BaseTaskresultlog
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("task")]
    [StringLength(50)]
    public string Task { get; set; } = null!;

    [Column("status")]
    [StringLength(10)]
    public string Status { get; set; } = null!;

    [Column("result")]
    [StringLength(500)]
    public string Result { get; set; } = null!;

    [Column("time", TypeName = "datetime")]
    public DateTime Time { get; set; }
}
