using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("acc_acccombination")]
[Index("AreaId", Name = "acc_acccombination_area_id_0d22c34e")]
[Index("AreaId", "CombinationNo", Name = "acc_acccombination_area_id_combination_no_619eb4f5_uniq", IsUnique = true)]
public partial class AccAcccombination
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

    [Column("combination_no")]
    public int CombinationNo { get; set; }

    [Column("combination_name")]
    [StringLength(100)]
    public string CombinationName { get; set; } = null!;

    [Column("group1")]
    public int? Group1 { get; set; }

    [Column("group2")]
    public int? Group2 { get; set; }

    [Column("group3")]
    public int? Group3 { get; set; }

    [Column("group4")]
    public int? Group4 { get; set; }

    [Column("group5")]
    public int? Group5 { get; set; }

    [Column("remark")]
    [StringLength(999)]
    public string? Remark { get; set; }

    [Column("update_time", TypeName = "datetime")]
    public DateTime? UpdateTime { get; set; }

    [Column("area_id")]
    public int AreaId { get; set; }

    [ForeignKey("AreaId")]
    [InverseProperty("AccAcccombinations")]
    public virtual PersonnelArea Area { get; set; } = null!;
}
