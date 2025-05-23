using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("base_attparamdepts")]
[Index("Rulename", Name = "UQ__base_att__14AA806DFAD0B844", IsUnique = true)]
public partial class BaseAttparamdept
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("rulename")]
    [StringLength(40)]
    public string Rulename { get; set; } = null!;

    [Column("deptid")]
    public int Deptid { get; set; }

    [Column("operator")]
    [StringLength(20)]
    public string? Operator { get; set; }

    [Column("optime", TypeName = "datetime")]
    public DateTime? Optime { get; set; }
}
