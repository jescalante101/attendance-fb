using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("acc_acctimezone")]
[Index("AreaId", Name = "acc_acctimezone_area_id_e9ce7a7a")]
[Index("AreaId", "TimezoneNo", Name = "acc_acctimezone_area_id_timezone_no_0cb8250f_uniq", IsUnique = true)]
public partial class AccAcctimezone
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

    [Column("timezone_no")]
    public int TimezoneNo { get; set; }

    [Column("timezone_name")]
    [StringLength(100)]
    public string TimezoneName { get; set; } = null!;

    [Column("sun_start", TypeName = "datetime")]
    public DateTime SunStart { get; set; }

    [Column("sun_end", TypeName = "datetime")]
    public DateTime SunEnd { get; set; }

    [Column("sun_on")]
    public short? SunOn { get; set; }

    [Column("mon_start", TypeName = "datetime")]
    public DateTime MonStart { get; set; }

    [Column("mon_end", TypeName = "datetime")]
    public DateTime MonEnd { get; set; }

    [Column("mon_on")]
    public short? MonOn { get; set; }

    [Column("tue_start", TypeName = "datetime")]
    public DateTime TueStart { get; set; }

    [Column("tue_end", TypeName = "datetime")]
    public DateTime TueEnd { get; set; }

    [Column("tue_on")]
    public short? TueOn { get; set; }

    [Column("wed_start", TypeName = "datetime")]
    public DateTime WedStart { get; set; }

    [Column("wed_end", TypeName = "datetime")]
    public DateTime WedEnd { get; set; }

    [Column("wed_on")]
    public short? WedOn { get; set; }

    [Column("thu_start", TypeName = "datetime")]
    public DateTime ThuStart { get; set; }

    [Column("thu_end", TypeName = "datetime")]
    public DateTime ThuEnd { get; set; }

    [Column("thu_on")]
    public short? ThuOn { get; set; }

    [Column("fri_start", TypeName = "datetime")]
    public DateTime FriStart { get; set; }

    [Column("fri_end", TypeName = "datetime")]
    public DateTime FriEnd { get; set; }

    [Column("fri_on")]
    public short? FriOn { get; set; }

    [Column("sat_start", TypeName = "datetime")]
    public DateTime SatStart { get; set; }

    [Column("sat_end", TypeName = "datetime")]
    public DateTime SatEnd { get; set; }

    [Column("sat_on")]
    public short? SatOn { get; set; }

    [Column("remark")]
    [StringLength(999)]
    public string? Remark { get; set; }

    [Column("update_time", TypeName = "datetime")]
    public DateTime? UpdateTime { get; set; }

    [Column("area_id")]
    public int AreaId { get; set; }

    [InverseProperty("Timezone")]
    public virtual ICollection<AccAccholiday> AccAccholidays { get; set; } = new List<AccAccholiday>();

    [ForeignKey("AreaId")]
    [InverseProperty("AccAcctimezones")]
    public virtual PersonnelArea Area { get; set; } = null!;
}
