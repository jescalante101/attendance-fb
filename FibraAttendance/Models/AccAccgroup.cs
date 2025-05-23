using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("acc_accgroups")]
[Index("AreaId", Name = "acc_accgroups_area_id_b83745c3")]
[Index("AreaId", "GroupNo", Name = "acc_accgroups_area_id_group_no_5130a89c_uniq", IsUnique = true)]
public partial class AccAccgroup
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

    [Column("group_no")]
    public int GroupNo { get; set; }

    [Column("group_name")]
    [StringLength(100)]
    public string GroupName { get; set; } = null!;

    [Column("verify_mode")]
    public int VerifyMode { get; set; }

    [Column("timezone1")]
    public int? Timezone1 { get; set; }

    [Column("timezone2")]
    public int? Timezone2 { get; set; }

    [Column("timezone3")]
    public int? Timezone3 { get; set; }

    [Column("is_include_holiday")]
    public short IsIncludeHoliday { get; set; }

    [Column("update_time", TypeName = "datetime")]
    public DateTime? UpdateTime { get; set; }

    [Column("area_id")]
    public int AreaId { get; set; }

    [InverseProperty("Group")]
    public virtual ICollection<AccAccprivilege> AccAccprivileges { get; set; } = new List<AccAccprivilege>();

    [ForeignKey("AreaId")]
    [InverseProperty("AccAccgroups")]
    public virtual PersonnelArea Area { get; set; } = null!;
}
