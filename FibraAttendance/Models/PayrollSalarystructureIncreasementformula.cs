using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("payroll_salarystructure_increasementformula")]
[Index("IncreasementformulaId", Name = "payroll_salarystructure_increasementformula_increasementformula_id_3cd77082")]
[Index("SalarystructureId", Name = "payroll_salarystructure_increasementformula_salarystructure_id_8752401c")]
[Index("SalarystructureId", "IncreasementformulaId", Name = "payroll_salarystructure_increasementformula_salarystructure_id_increasementformula_id_749132b3_uniq", IsUnique = true)]
public partial class PayrollSalarystructureIncreasementformula
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("salarystructure_id")]
    public int SalarystructureId { get; set; }

    [Column("increasementformula_id")]
    public int IncreasementformulaId { get; set; }

    [ForeignKey("IncreasementformulaId")]
    [InverseProperty("PayrollSalarystructureIncreasementformulas")]
    public virtual PayrollIncreasementformula Increasementformula { get; set; } = null!;

    [ForeignKey("SalarystructureId")]
    [InverseProperty("PayrollSalarystructureIncreasementformulas")]
    public virtual PayrollSalarystructure Salarystructure { get; set; } = null!;
}
