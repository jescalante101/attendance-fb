using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("personnel_certification")]
[Index("CertName", Name = "UQ__personne__1B8BDCA7B88488B2", IsUnique = true)]
[Index("CertCode", Name = "UQ__personne__34D3AE57A5BE0935", IsUnique = true)]
public partial class PersonnelCertification
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("cert_code")]
    [StringLength(20)]
    public string CertCode { get; set; } = null!;

    [Column("cert_name")]
    [StringLength(50)]
    public string CertName { get; set; } = null!;

    [InverseProperty("Certification")]
    public virtual ICollection<PersonnelEmployeecertification> PersonnelEmployeecertifications { get; set; } = new List<PersonnelEmployeecertification>();
}
