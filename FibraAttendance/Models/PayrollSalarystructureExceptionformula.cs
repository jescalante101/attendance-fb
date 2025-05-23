using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("payroll_salarystructure_exceptionformula")]
[Index("ExceptionformulaId", Name = "payroll_salarystructure_exceptionformula_exceptionformula_id_8f6dadb3")]
[Index("SalarystructureId", Name = "payroll_salarystructure_exceptionformula_salarystructure_id_3c087208")]
[Index("SalarystructureId", "ExceptionformulaId", Name = "payroll_salarystructure_exceptionformula_salarystructure_id_exceptionformula_id_a5e869ff_uniq", IsUnique = true)]
public partial class PayrollSalarystructureExceptionformula
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("salarystructure_id")]
    public int SalarystructureId { get; set; }

    [Column("exceptionformula_id")]
    public int ExceptionformulaId { get; set; }

    [ForeignKey("ExceptionformulaId")]
    [InverseProperty("PayrollSalarystructureExceptionformulas")]
    public virtual PayrollExceptionformula Exceptionformula { get; set; } = null!;

    [ForeignKey("SalarystructureId")]
    [InverseProperty("PayrollSalarystructureExceptionformulas")]
    public virtual PayrollSalarystructure Salarystructure { get; set; } = null!;
}
