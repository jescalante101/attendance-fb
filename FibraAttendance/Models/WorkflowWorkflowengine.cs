using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("workflow_workflowengine")]
[Index("WorkflowCode", Name = "UQ__workflow__12BE0D466E8FFF58", IsUnique = true)]
[Index("ApplicantPositionId", Name = "workflow_workflowengine_applicant_position_id_8a65e03a")]
[Index("ContentTypeId", Name = "workflow_workflowengine_content_type_id_f7345c20")]
[Index("DepartmentsId", Name = "workflow_workflowengine_departments_id_0f06d4c7")]
public partial class WorkflowWorkflowengine
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("workflow_code")]
    [StringLength(50)]
    public string WorkflowCode { get; set; } = null!;

    [Column("workflow_name")]
    [StringLength(50)]
    public string WorkflowName { get; set; } = null!;

    [Column("start_date", TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column("end_date", TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    [Column("description")]
    [StringLength(50)]
    public string Description { get; set; } = null!;

    [Column("workflow_type")]
    public short WorkflowType { get; set; }

    [Column("inform_type")]
    public short InformType { get; set; }

    [Column("del_flag")]
    public short? DelFlag { get; set; }

    [Column("applicant_position_id")]
    public int? ApplicantPositionId { get; set; }

    [Column("content_type_id")]
    public int? ContentTypeId { get; set; }

    [Column("departments_id")]
    public int? DepartmentsId { get; set; }

    [ForeignKey("ApplicantPositionId")]
    [InverseProperty("WorkflowWorkflowengines")]
    public virtual PersonnelPosition? ApplicantPosition { get; set; }

    [ForeignKey("ContentTypeId")]
    [InverseProperty("WorkflowWorkflowengines")]
    public virtual DjangoContentType? ContentType { get; set; }

    [ForeignKey("DepartmentsId")]
    [InverseProperty("WorkflowWorkflowengines")]
    public virtual PersonnelDepartment? Departments { get; set; }

    [InverseProperty("Workflowengine")]
    public virtual ICollection<WorkflowWorkflowengineEmployee> WorkflowWorkflowengineEmployees { get; set; } = new List<WorkflowWorkflowengineEmployee>();

    [InverseProperty("WorkflowEngine")]
    public virtual ICollection<WorkflowWorkflowinstance> WorkflowWorkflowinstances { get; set; } = new List<WorkflowWorkflowinstance>();
}
