using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("workflow_workflowengine_employee")]
[Index("EmployeeId", Name = "workflow_workflowengine_employee_employee_id_803a409e")]
[Index("WorkflowengineId", Name = "workflow_workflowengine_employee_workflowengine_id_6ebcc5f2")]
[Index("WorkflowengineId", "EmployeeId", Name = "workflow_workflowengine_employee_workflowengine_id_employee_id_8128deb2_uniq", IsUnique = true)]
public partial class WorkflowWorkflowengineEmployee
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("workflowengine_id")]
    public int WorkflowengineId { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("WorkflowWorkflowengineEmployees")]
    public virtual PersonnelEmployee Employee { get; set; } = null!;

    [ForeignKey("WorkflowengineId")]
    [InverseProperty("WorkflowWorkflowengineEmployees")]
    public virtual WorkflowWorkflowengine Workflowengine { get; set; } = null!;
}
