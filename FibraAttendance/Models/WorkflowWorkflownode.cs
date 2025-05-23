using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("workflow_workflownode")]
public partial class WorkflowWorkflownode
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("node_code")]
    [StringLength(30)]
    public string NodeCode { get; set; } = null!;

    [Column("node_name")]
    [StringLength(30)]
    public string NodeName { get; set; } = null!;

    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("approver_type")]
    public short? ApproverType { get; set; }

    [Column("notifier_type")]
    public short? NotifierType { get; set; }

    [Column("approver_by_overall")]
    public bool ApproverByOverall { get; set; }

    [Column("notify_by_overall")]
    public bool NotifyByOverall { get; set; }

    [Column("workflow_engine")]
    public int WorkflowEngine { get; set; }

    [Column("workflow_engine_name")]
    [StringLength(50)]
    public string WorkflowEngineName { get; set; } = null!;

    [InverseProperty("NodeEngine")]
    public virtual ICollection<WorkflowNodeinstance> WorkflowNodeinstances { get; set; } = new List<WorkflowNodeinstance>();

    [InverseProperty("Workflownode")]
    public virtual ICollection<WorkflowWorkflownodeApprover> WorkflowWorkflownodeApprovers { get; set; } = new List<WorkflowWorkflownodeApprover>();

    [InverseProperty("Workflownode")]
    public virtual ICollection<WorkflowWorkflownodeNotifier> WorkflowWorkflownodeNotifiers { get; set; } = new List<WorkflowWorkflownodeNotifier>();
}
