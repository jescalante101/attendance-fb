using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_payloadpunch")]
[Index("EmpId", Name = "att_payloadpunch_emp_id_053da2f0")]
[Index("OrigId", Name = "att_payloadpunch_orig_id_16b26416")]
[Index("SkdId", Name = "att_payloadpunch_skd_id_17596d82")]
public partial class AttPayloadpunch
{
    [Key]
    [Column("uuid")]
    [StringLength(36)]
    public string Uuid { get; set; } = null!;

    [Column("att_date", TypeName = "datetime")]
    public DateTime? AttDate { get; set; }

    [Column("correct_state")]
    [StringLength(3)]
    public string? CorrectState { get; set; }

    [Column("emp_id")]
    public int EmpId { get; set; }

    [Column("orig_id")]
    public int? OrigId { get; set; }

    [Column("skd_id")]
    [StringLength(36)]
    public string? SkdId { get; set; }

    [ForeignKey("EmpId")]
    [InverseProperty("AttPayloadpunches")]
    public virtual PersonnelEmployee Emp { get; set; } = null!;

    [ForeignKey("OrigId")]
    [InverseProperty("AttPayloadpunches")]
    public virtual IclockTransaction? Orig { get; set; }
}
