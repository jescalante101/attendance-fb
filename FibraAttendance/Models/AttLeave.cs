using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_leave")]
[Index("CategoryId", Name = "att_leave_category_id_bbba39ba")]
[Index("EmployeeId", Name = "att_leave_employee_id_bb231627")]
public partial class AttLeave
{
    [Key]
    [Column("abstractexception_ptr_id")]
    public int AbstractexceptionPtrId { get; set; }

    [Column("start_time", TypeName = "datetime")]
    public DateTime StartTime { get; set; }

    [Column("end_time", TypeName = "datetime")]
    public DateTime EndTime { get; set; }

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

    [Column("category_id")]
    public int CategoryId { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [ForeignKey("AbstractexceptionPtrId")]
    [InverseProperty("AttLeave")]
    public virtual WorkflowAbstractexception AbstractexceptionPtr { get; set; } = null!;

    [InverseProperty("Item")]
    public virtual ICollection<AttPayloadexception> AttPayloadexceptions { get; set; } = new List<AttPayloadexception>();

    [ForeignKey("CategoryId")]
    [InverseProperty("AttLeaves")]
    public virtual AttLeavecategory Category { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("AttLeaves")]
    public virtual PersonnelEmployee Employee { get; set; } = null!;
}
