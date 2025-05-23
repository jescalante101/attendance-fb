using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("payroll_increasementformula")]
public partial class PayrollIncreasementformula
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(30)]
    public string Name { get; set; } = null!;

    [Column("formula")]
    [StringLength(100)]
    public string Formula { get; set; } = null!;

    [Column("remark")]
    public string? Remark { get; set; }

    [InverseProperty("Increasementformula")]
    public virtual ICollection<PayrollSalarystructureIncreasementformula> PayrollSalarystructureIncreasementformulas { get; set; } = new List<PayrollSalarystructureIncreasementformula>();
}
