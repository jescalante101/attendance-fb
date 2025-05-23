using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("djcelery_crontabschedule")]
public partial class DjceleryCrontabschedule
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("minute")]
    [StringLength(64)]
    public string Minute { get; set; } = null!;

    [Column("hour")]
    [StringLength(64)]
    public string Hour { get; set; } = null!;

    [Column("day_of_week")]
    [StringLength(64)]
    public string DayOfWeek { get; set; } = null!;

    [Column("day_of_month")]
    [StringLength(64)]
    public string DayOfMonth { get; set; } = null!;

    [Column("month_of_year")]
    [StringLength(64)]
    public string MonthOfYear { get; set; } = null!;

    [InverseProperty("Crontab")]
    public virtual ICollection<DjceleryPeriodictask> DjceleryPeriodictasks { get; set; } = new List<DjceleryPeriodictask>();
}
