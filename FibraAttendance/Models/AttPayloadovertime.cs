using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_payloadovertime")]
public partial class AttPayloadovertime
{
    [Key]
    [Column("uuid")]
    [StringLength(36)]
    public string Uuid { get; set; } = null!;

    [Column("normal_wt")]
    public int? NormalWt { get; set; }

    [Column("normal_ot")]
    public int? NormalOt { get; set; }

    [Column("weekend_ot")]
    public int? WeekendOt { get; set; }

    [Column("holiday_ot")]
    public int? HolidayOt { get; set; }

    [Column("ot_lv1")]
    public int? OtLv1 { get; set; }

    [Column("ot_lv2")]
    public int? OtLv2 { get; set; }

    [Column("ot_lv3")]
    public int? OtLv3 { get; set; }

    [Column("total_ot")]
    public int? TotalOt { get; set; }
}
