using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("workflow_workflownode_approver")]
[Index("WorkflownodeId", Name = "workflow_workflownode_approver_workflownode_id_d814c941")]
[Index("WorkflownodeId", "WorkflowroleId", Name = "workflow_workflownode_approver_workflownode_id_workflowrole_id_7543ba37_uniq", IsUnique = true)]
[Index("WorkflowroleId", Name = "workflow_workflownode_approver_workflowrole_id_c8e00d42")]
public partial class WorkflowWorkflownodeApprover
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("workflownode_id")]
    public int WorkflownodeId { get; set; }

    [Column("workflowrole_id")]
    public int WorkflowroleId { get; set; }

    [ForeignKey("WorkflownodeId")]
    [InverseProperty("WorkflowWorkflownodeApprovers")]
    public virtual WorkflowWorkflownode Workflownode { get; set; } = null!;

    [ForeignKey("WorkflowroleId")]
    [InverseProperty("WorkflowWorkflownodeApprovers")]
    public virtual WorkflowWorkflowrole Workflowrole { get; set; } = null!;
}
