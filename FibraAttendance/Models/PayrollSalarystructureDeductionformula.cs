using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("payroll_salarystructure_deductionformula")]
[Index("DeductionformulaId", Name = "payroll_salarystructure_deductionformula_deductionformula_id_b174d5b6")]
[Index("SalarystructureId", Name = "payroll_salarystructure_deductionformula_salarystructure_id_5ca7cdb5")]
[Index("SalarystructureId", "DeductionformulaId", Name = "payroll_salarystructure_deductionformula_salarystructure_id_deductionformula_id_794e8449_uniq", IsUnique = true)]
public partial class PayrollSalarystructureDeductionformula
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("salarystructure_id")]
    public int SalarystructureId { get; set; }

    [Column("deductionformula_id")]
    public int DeductionformulaId { get; set; }

    [ForeignKey("DeductionformulaId")]
    [InverseProperty("PayrollSalarystructureDeductionformulas")]
    public virtual PayrollDeductionformula Deductionformula { get; set; } = null!;

    [ForeignKey("SalarystructureId")]
    [InverseProperty("PayrollSalarystructureDeductionformulas")]
    public virtual PayrollSalarystructure Salarystructure { get; set; } = null!;
}
