using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("personnel_resign")]
[Index("EmployeeId", Name = "UQ__personne__C52E0BA9696B484C", IsUnique = true)]
public partial class PersonnelResign
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("resign_date", TypeName = "datetime")]
    public DateTime ResignDate { get; set; }

    [Column("resign_type")]
    public int? ResignType { get; set; }

    [Column("reason")]
    [StringLength(200)]
    public string? Reason { get; set; }

    [Column("disableatt")]
    public bool Disableatt { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("PersonnelResign")]
    public virtual PersonnelEmployee Employee { get; set; } = null!;
}
