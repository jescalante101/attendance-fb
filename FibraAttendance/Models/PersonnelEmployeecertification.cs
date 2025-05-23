using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("personnel_employeecertification")]
[Index("CertificationId", Name = "personnel_employeecertification_certification_id_faabed40")]
[Index("EmployeeId", Name = "personnel_employeecertification_employee_id_b7bd3867")]
[Index("EmployeeId", "CertificationId", Name = "personnel_employeecertification_employee_id_certification_id_7bcf4c7d_uniq", IsUnique = true)]
public partial class PersonnelEmployeecertification
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("expire_on", TypeName = "datetime")]
    public DateTime? ExpireOn { get; set; }

    [Column("email_alert")]
    public bool EmailAlert { get; set; }

    [Column("before")]
    public int? Before { get; set; }

    [Column("certification_id")]
    public int CertificationId { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [ForeignKey("CertificationId")]
    [InverseProperty("PersonnelEmployeecertifications")]
    public virtual PersonnelCertification Certification { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("PersonnelEmployeecertifications")]
    public virtual PersonnelEmployee Employee { get; set; } = null!;
}
