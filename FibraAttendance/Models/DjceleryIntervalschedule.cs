using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("djcelery_intervalschedule")]
public partial class DjceleryIntervalschedule
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("every")]
    public int Every { get; set; }

    [Column("period")]
    [StringLength(24)]
    public string Period { get; set; } = null!;

    [InverseProperty("Interval")]
    public virtual ICollection<DjceleryPeriodictask> DjceleryPeriodictasks { get; set; } = new List<DjceleryPeriodictask>();
}
