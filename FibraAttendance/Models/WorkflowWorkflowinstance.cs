using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("workflow_workflowinstance")]
[Index("ExceptionId", Name = "UQ__workflow__C42DECC3A6D6D6DC", IsUnique = true)]
[Index("EmployeeId", Name = "workflow_workflowinstance_employee_id_c7cff08e")]
[Index("WorkflowEngineId", Name = "workflow_workflowinstance_workflow_engine_id_1e6ac40f")]
public partial class WorkflowWorkflowinstance
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("workflow_code")]
    [StringLength(255)]
    public string WorkflowCode { get; set; } = null!;

    [Column("workflow_name")]
    [StringLength(255)]
    public string WorkflowName { get; set; } = null!;

    [Column("start_date", TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column("end_date", TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    [Column("issue_date", TypeName = "datetime")]
    public DateTime IssueDate { get; set; }

    [Column("description")]
    [StringLength(255)]
    public string Description { get; set; } = null!;

    [Column("content_type")]
    public int ContentType { get; set; }

    [Column("inform_type")]
    public short InformType { get; set; }

    [Column("del_flag")]
    public bool DelFlag { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Column("exception_id")]
    public int? ExceptionId { get; set; }

    [Column("workflow_engine_id")]
    public int? WorkflowEngineId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("WorkflowWorkflowinstances")]
    public virtual PersonnelEmployee Employee { get; set; } = null!;

    [ForeignKey("ExceptionId")]
    [InverseProperty("WorkflowWorkflowinstance")]
    public virtual WorkflowAbstractexception? Exception { get; set; }

    [ForeignKey("WorkflowEngineId")]
    [InverseProperty("WorkflowWorkflowinstances")]
    public virtual WorkflowWorkflowengine? WorkflowEngine { get; set; }

    [InverseProperty("WorkflowInstance")]
    public virtual ICollection<WorkflowNodeinstance> WorkflowNodeinstances { get; set; } = new List<WorkflowNodeinstance>();
}
