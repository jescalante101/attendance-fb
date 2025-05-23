using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("payroll_exceptionformula")]
public partial class PayrollExceptionformula
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(30)]
    public string Name { get; set; } = null!;

    [Column("exception_type")]
    public short ExceptionType { get; set; }

    [Column("formula")]
    [StringLength(100)]
    public string Formula { get; set; } = null!;

    [Column("remark")]
    public string? Remark { get; set; }

    [InverseProperty("Exceptionformula")]
    public virtual ICollection<PayrollSalarystructureExceptionformula> PayrollSalarystructureExceptionformulas { get; set; } = new List<PayrollSalarystructureExceptionformula>();
}
