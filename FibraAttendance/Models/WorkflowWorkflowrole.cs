using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("workflow_workflowrole")]
[Index("RoleName", Name = "UQ__workflow__783254B156C5B0D6", IsUnique = true)]
[Index("RoleCode", Name = "UQ__workflow__BAE63075EC33AEA4", IsUnique = true)]
public partial class WorkflowWorkflowrole
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("role_code")]
    [StringLength(30)]
    public string RoleCode { get; set; } = null!;

    [Column("role_name")]
    [StringLength(50)]
    public string RoleName { get; set; } = null!;

    [Column("description")]
    [StringLength(200)]
    public string? Description { get; set; }

    [InverseProperty("Workflowrole")]
    public virtual ICollection<PersonnelEmployeeFlowRole> PersonnelEmployeeFlowRoles { get; set; } = new List<PersonnelEmployeeFlowRole>();

    [InverseProperty("Workflowrole")]
    public virtual ICollection<WorkflowWorkflownodeApprover> WorkflowWorkflownodeApprovers { get; set; } = new List<WorkflowWorkflownodeApprover>();

    [InverseProperty("Workflowrole")]
    public virtual ICollection<WorkflowWorkflownodeNotifier> WorkflowWorkflownodeNotifiers { get; set; } = new List<WorkflowWorkflownodeNotifier>();
}
