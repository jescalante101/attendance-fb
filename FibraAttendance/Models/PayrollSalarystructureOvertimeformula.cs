using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("payroll_salarystructure_overtimeformula")]
[Index("OvertimeformulaId", Name = "payroll_salarystructure_overtimeformula_overtimeformula_id_40ad89ef")]
[Index("SalarystructureId", Name = "payroll_salarystructure_overtimeformula_salarystructure_id_64f75042")]
[Index("SalarystructureId", "OvertimeformulaId", Name = "payroll_salarystructure_overtimeformula_salarystructure_id_overtimeformula_id_0d0a0e81_uniq", IsUnique = true)]
public partial class PayrollSalarystructureOvertimeformula
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("salarystructure_id")]
    public int SalarystructureId { get; set; }

    [Column("overtimeformula_id")]
    public int OvertimeformulaId { get; set; }

    [ForeignKey("OvertimeformulaId")]
    [InverseProperty("PayrollSalarystructureOvertimeformulas")]
    public virtual PayrollOvertimeformula Overtimeformula { get; set; } = null!;

    [ForeignKey("SalarystructureId")]
    [InverseProperty("PayrollSalarystructureOvertimeformulas")]
    public virtual PayrollSalarystructure Salarystructure { get; set; } = null!;
}
