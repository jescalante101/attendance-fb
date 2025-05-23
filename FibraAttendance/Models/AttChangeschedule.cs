using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_changeschedule")]
[Index("EmployeeId", Name = "att_changeschedule_employee_id_7871a2b6")]
[Index("TimeintervalId", Name = "att_changeschedule_timeinterval_id_d41ac077")]
public partial class AttChangeschedule
{
    [Key]
    [Column("abstractexception_ptr_id")]
    public int AbstractexceptionPtrId { get; set; }

    [Column("att_date", TypeName = "datetime")]
    public DateTime AttDate { get; set; }

    [Column("previous_timeinterval")]
    [StringLength(100)]
    public string? PreviousTimeinterval { get; set; }

    [Column("apply_time", TypeName = "datetime")]
    public DateTime ApplyTime { get; set; }

    [Column("apply_reason")]
    [StringLength(200)]
    public string? ApplyReason { get; set; }

    [Column("audit_reason")]
    public string? AuditReason { get; set; }

    [Column("audit_time", TypeName = "datetime")]
    public DateTime AuditTime { get; set; }

    [Column("approver")]
    [StringLength(50)]
    public string? Approver { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Column("timeinterval_id")]
    public int TimeintervalId { get; set; }

    [ForeignKey("AbstractexceptionPtrId")]
    [InverseProperty("AttChangeschedule")]
    public virtual WorkflowAbstractexception AbstractexceptionPtr { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("AttChangeschedules")]
    public virtual PersonnelEmployee Employee { get; set; } = null!;

    [ForeignKey("TimeintervalId")]
    [InverseProperty("AttChangeschedules")]
    public virtual AttTimeinterval Timeinterval { get; set; } = null!;
}
