using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("payroll_leaveformula")]
[Index("CategoryId", Name = "payroll_leaveformula_category_id_945b2054")]
public partial class PayrollLeaveformula
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

    [Column("category_id")]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("PayrollLeaveformulas")]
    public virtual AttLeavecategory Category { get; set; } = null!;

    [InverseProperty("Leaveformula")]
    public virtual ICollection<PayrollSalarystructureLeaveformula> PayrollSalarystructureLeaveformulas { get; set; } = new List<PayrollSalarystructureLeaveformula>();
}
