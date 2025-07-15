using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("workflow_abstractexception")]
public partial class WorkflowAbstractexception
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("audit_status")]
    public short AuditStatus { get; set; }

    [Column("revoke_reason")]
    public string? RevokeReason { get; set; }

    [InverseProperty("AbstractexceptionPtr")]
    public virtual AttChangeschedule? AttChangeschedule { get; set; }

    [InverseProperty("AbstractexceptionPtr")]
    public virtual AttLeave? AttLeave { get; set; }

    //[InverseProperty("AbstractexceptionPtr")]
    //public virtual AttManuallog? AttManuallog { get; set; }

    [InverseProperty("AbstractexceptionPtr")]
    public virtual AttOvertime? AttOvertime { get; set; }

    [InverseProperty("AbstractexceptionPtr")]
    public virtual AttTraining? AttTraining { get; set; }

    [InverseProperty("Exception")]
    public virtual WorkflowWorkflowinstance? WorkflowWorkflowinstance { get; set; }
}
