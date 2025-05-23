using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("personnel_employee_flow_role")]
[Index("EmployeeId", Name = "personnel_employee_flow_role_employee_id_c27f8a56")]
[Index("EmployeeId", "WorkflowroleId", Name = "personnel_employee_flow_role_employee_id_workflowrole_id_46b0e5e0_uniq", IsUnique = true)]
[Index("WorkflowroleId", Name = "personnel_employee_flow_role_workflowrole_id_4704db32")]
public partial class PersonnelEmployeeFlowRole
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Column("workflowrole_id")]
    public int WorkflowroleId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("PersonnelEmployeeFlowRoles")]
    public virtual PersonnelEmployee Employee { get; set; } = null!;

    [ForeignKey("WorkflowroleId")]
    [InverseProperty("PersonnelEmployeeFlowRoles")]
    public virtual WorkflowWorkflowrole Workflowrole { get; set; } = null!;
}
