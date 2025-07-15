using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_manuallog")]
[Index("EmployeeId", Name = "att_manuallog_employee_id_dc8cc2ad")]
public partial class AttManuallog
{
    [Key]
    [Column("abstractexception_ptr_id")]
    public int AbstractexceptionPtrId { get; set; }

    [Column("punch_time", TypeName = "datetime")]
    public DateTime PunchTime { get; set; }

    [Column("punch_state")]
    public int PunchState { get; set; }

    [Column("work_code")]
    [StringLength(20)]
    public string? WorkCode { get; set; }

    [Column("apply_reason")]
    public string? ApplyReason { get; set; }

    [Column("apply_time", TypeName = "datetime")]
    public DateTime ApplyTime { get; set; }

    [Column("audit_reason")]
    public string? AuditReason { get; set; }

    [Column("audit_time", TypeName = "datetime")]
    public DateTime AuditTime { get; set; }

    [Column("approval_level")]
    public short? ApprovalLevel { get; set; }

    [Column("audit_user_id")]
    public int? AuditUserId { get; set; }

    [Column("approver")]
    [StringLength(50)]
    public string? Approver { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Column("is_mask")]
    public bool IsMask { get; set; }

    [Column("temperature", TypeName = "numeric(4, 1)")]
    public decimal? Temperature { get; set; }

    [Column("nro_doc")]
    [StringLength(20)]
    public string? NroDoc { get; set; }

    [ForeignKey("AbstractexceptionPtrId")]
    [InverseProperty("AttManuallog")]
    public virtual WorkflowAbstractexception AbstractexceptionPtr { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("AttManuallogs")]
    public virtual PersonnelEmployee Employee { get; set; } = null!;
}
