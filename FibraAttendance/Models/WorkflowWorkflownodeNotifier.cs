using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("workflow_workflownode_notifier")]
[Index("WorkflownodeId", Name = "workflow_workflownode_notifier_workflownode_id_57298016")]
[Index("WorkflownodeId", "WorkflowroleId", Name = "workflow_workflownode_notifier_workflownode_id_workflowrole_id_cac02b37_uniq", IsUnique = true)]
[Index("WorkflowroleId", Name = "workflow_workflownode_notifier_workflowrole_id_73de7fc2")]
public partial class WorkflowWorkflownodeNotifier
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("workflownode_id")]
    public int WorkflownodeId { get; set; }

    [Column("workflowrole_id")]
    public int WorkflowroleId { get; set; }

    [ForeignKey("WorkflownodeId")]
    [InverseProperty("WorkflowWorkflownodeNotifiers")]
    public virtual WorkflowWorkflownode Workflownode { get; set; } = null!;

    [ForeignKey("WorkflowroleId")]
    [InverseProperty("WorkflowWorkflownodeNotifiers")]
    public virtual WorkflowWorkflowrole Workflowrole { get; set; } = null!;
}
