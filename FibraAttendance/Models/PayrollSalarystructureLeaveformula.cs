using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("payroll_salarystructure_leaveformula")]
[Index("LeaveformulaId", Name = "payroll_salarystructure_leaveformula_leaveformula_id_049f9024")]
[Index("SalarystructureId", Name = "payroll_salarystructure_leaveformula_salarystructure_id_cf98fdd7")]
[Index("SalarystructureId", "LeaveformulaId", Name = "payroll_salarystructure_leaveformula_salarystructure_id_leaveformula_id_4efdce30_uniq", IsUnique = true)]
public partial class PayrollSalarystructureLeaveformula
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("salarystructure_id")]
    public int SalarystructureId { get; set; }

    [Column("leaveformula_id")]
    public int LeaveformulaId { get; set; }

    [ForeignKey("LeaveformulaId")]
    [InverseProperty("PayrollSalarystructureLeaveformulas")]
    public virtual PayrollLeaveformula Leaveformula { get; set; } = null!;

    [ForeignKey("SalarystructureId")]
    [InverseProperty("PayrollSalarystructureLeaveformulas")]
    public virtual PayrollSalarystructure Salarystructure { get; set; } = null!;
}
