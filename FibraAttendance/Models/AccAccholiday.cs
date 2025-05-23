using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("acc_accholiday")]
[Index("AreaId", Name = "acc_accholiday_area_id_d15c19da")]
[Index("AreaId", "HolidayId", Name = "acc_accholiday_area_id_holiday_id_6630c2eb_uniq", IsUnique = true)]
[Index("HolidayId", Name = "acc_accholiday_holiday_id_a9efe924")]
[Index("TimezoneId", Name = "acc_accholiday_timezone_id_450d2d1e")]
public partial class AccAccholiday
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

    [Column("update_time", TypeName = "datetime")]
    public DateTime? UpdateTime { get; set; }

    [Column("area_id")]
    public int AreaId { get; set; }

    [Column("holiday_id")]
    public int HolidayId { get; set; }

    [Column("timezone_id")]
    public int TimezoneId { get; set; }

    [ForeignKey("AreaId")]
    [InverseProperty("AccAccholidays")]
    public virtual PersonnelArea Area { get; set; } = null!;

    [ForeignKey("HolidayId")]
    [InverseProperty("AccAccholidays")]
    public virtual AttHoliday Holiday { get; set; } = null!;

    [ForeignKey("TimezoneId")]
    [InverseProperty("AccAccholidays")]
    public virtual AccAcctimezone Timezone { get; set; } = null!;
}
