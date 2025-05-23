using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("workflow_nodeinstance")]
[Index("ApproverAdminId", Name = "workflow_nodeinstance_approver_admin_id_dff58806")]
[Index("ApproverEmployeeId", Name = "workflow_nodeinstance_approver_employee_id_d36cd45d")]
[Index("DepartmentsId", Name = "workflow_nodeinstance_departments_id_b0dc2bdb")]
[Index("NodeEngineId", Name = "workflow_nodeinstance_node_engine_id_4533f12d")]
[Index("WorkflowInstanceId", Name = "workflow_nodeinstance_workflow_instance_id_afe84fe4")]
public partial class WorkflowNodeinstance
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(200)]
    public string Name { get; set; } = null!;

    [Column("order")]
    public short Order { get; set; }

    [Column("is_last_node")]
    public bool IsLastNode { get; set; }

    [Column("is_next_node")]
    public bool IsNextNode { get; set; }

    [Column("remark")]
    [StringLength(255)]
    public string? Remark { get; set; }

    [Column("apply_time", TypeName = "datetime")]
    public DateTime? ApplyTime { get; set; }

    [Column("approver_admin_id")]
    public int? ApproverAdminId { get; set; }

    [Column("approver_employee_id")]
    public int? ApproverEmployeeId { get; set; }

    [Column("departments_id")]
    public int? DepartmentsId { get; set; }

    [Column("node_engine_id")]
    public int? NodeEngineId { get; set; }

    [Column("state")]
    public short State { get; set; }

    [Column("workflow_instance_id")]
    public int? WorkflowInstanceId { get; set; }

    [ForeignKey("ApproverAdminId")]
    [InverseProperty("WorkflowNodeinstances")]
    public virtual AuthUser? ApproverAdmin { get; set; }

    [ForeignKey("ApproverEmployeeId")]
    [InverseProperty("WorkflowNodeinstances")]
    public virtual PersonnelEmployee? ApproverEmployee { get; set; }

    [ForeignKey("DepartmentsId")]
    [InverseProperty("WorkflowNodeinstances")]
    public virtual PersonnelDepartment? Departments { get; set; }

    [ForeignKey("NodeEngineId")]
    [InverseProperty("WorkflowNodeinstances")]
    public virtual WorkflowWorkflownode? NodeEngine { get; set; }

    [ForeignKey("WorkflowInstanceId")]
    [InverseProperty("WorkflowNodeinstances")]
    public virtual WorkflowWorkflowinstance? WorkflowInstance { get; set; }
}
