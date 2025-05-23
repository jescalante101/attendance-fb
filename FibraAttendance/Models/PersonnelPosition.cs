using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("personnel_position")]
[Index("PositionCode", Name = "UQ__personne__4B0D1EF8EF4A0DDA", IsUnique = true)]
[Index("ParentPositionId", Name = "personnel_position_parent_position_id_a496a36b")]
public partial class PersonnelPosition
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("position_code")]
    [StringLength(50)]
    public string PositionCode { get; set; } = null!;

    [Column("position_name")]
    [StringLength(100)]
    public string PositionName { get; set; } = null!;

    [Column("is_default")]
    public bool IsDefault { get; set; }

    [Column("parent_position_id")]
    public int? ParentPositionId { get; set; }

    [InverseProperty("ParentPosition")]
    public virtual ICollection<PersonnelPosition> InverseParentPosition { get; set; } = new List<PersonnelPosition>();

    [ForeignKey("ParentPositionId")]
    [InverseProperty("InverseParentPosition")]
    public virtual PersonnelPosition? ParentPosition { get; set; }

    [InverseProperty("Position")]
    public virtual ICollection<PersonnelEmployee> PersonnelEmployees { get; set; } = new List<PersonnelEmployee>();

    [InverseProperty("ApplicantPosition")]
    public virtual ICollection<WorkflowWorkflowengine> WorkflowWorkflowengines { get; set; } = new List<WorkflowWorkflowengine>();
}
