using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("iclock_biodata")]
[Index("EmployeeId", "BioNo", "BioIndex", "BioType", "BioFormat", "MajorVer", Name = "iclock_biodata_employee_id_bio_no_bio_index_bio_type_bio_format_major_ver_b71b2ca9_uniq", IsUnique = true)]
[Index("EmployeeId", Name = "iclock_biodata_employee_id_ff748ea7")]
public partial class IclockBiodatum
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

    [Column("bio_tmp")]
    public string BioTmp { get; set; } = null!;

    [Column("bio_no")]
    public int? BioNo { get; set; }

    [Column("bio_index")]
    public int? BioIndex { get; set; }

    [Column("bio_type")]
    public int BioType { get; set; }

    [Column("major_ver")]
    [StringLength(30)]
    public string MajorVer { get; set; } = null!;

    [Column("minor_ver")]
    [StringLength(30)]
    public string? MinorVer { get; set; }

    [Column("bio_format")]
    public int? BioFormat { get; set; }

    [Column("valid")]
    public int Valid { get; set; }

    [Column("duress")]
    public int Duress { get; set; }

    [Column("update_time", TypeName = "datetime")]
    public DateTime? UpdateTime { get; set; }

    [Column("sn")]
    [StringLength(50)]
    public string? Sn { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("IclockBiodata")]
    public virtual PersonnelEmployee Employee { get; set; } = null!;
}
