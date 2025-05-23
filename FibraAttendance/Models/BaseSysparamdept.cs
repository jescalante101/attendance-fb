using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("base_sysparamdept")]
[Index("RuleName", Name = "UQ__base_sys__B9ADD0FA107DF3E7", IsUnique = true)]
public partial class BaseSysparamdept
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("rule_name")]
    [StringLength(40)]
    public string RuleName { get; set; } = null!;

    [Column("dept_id")]
    public int DeptId { get; set; }

    [Column("operator")]
    [StringLength(20)]
    public string? Operator { get; set; }

    [Column("op_time", TypeName = "datetime")]
    public DateTime? OpTime { get; set; }
}
