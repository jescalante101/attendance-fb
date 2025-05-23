using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("payroll_overtimeformula")]
public partial class PayrollOvertimeformula
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(30)]
    public string Name { get; set; } = null!;

    [Column("overtime_level")]
    public short OvertimeLevel { get; set; }

    [Column("formula")]
    [StringLength(100)]
    public string Formula { get; set; } = null!;

    [Column("remark")]
    public string? Remark { get; set; }

    [InverseProperty("Overtimeformula")]
    public virtual ICollection<PayrollSalarystructureOvertimeformula> PayrollSalarystructureOvertimeformulas { get; set; } = new List<PayrollSalarystructureOvertimeformula>();
}
