using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("payroll_salarystructure")]
[Index("EmployeeId", Name = "payroll_salarystructure_employee_id_98996e15")]
public partial class PayrollSalarystructure
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("create_time", TypeName = "datetime")]
    public DateTime? CreateTime { get; set; }

    [Column("create_user")]
    [StringLength(150)]
    public string? CreateUser { get; set; }

    [Column("change_time", TypeName = "datetime")]
    public DateTime? ChangeTime { get; set; }

    [Column("change_user")]
    [StringLength(150)]
    public string? ChangeUser { get; set; }

    [Column("status")]
    public short Status { get; set; }

    [Column("salary_amount")]
    public double SalaryAmount { get; set; }

    [Column("effective_date", TypeName = "datetime")]
    public DateTime EffectiveDate { get; set; }

    [Column("salary_remark")]
    [StringLength(300)]
    public string? SalaryRemark { get; set; }

    [Column("employee_id")]
    public int? EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("PayrollSalarystructures")]
    public virtual PersonnelEmployee? Employee { get; set; }

    [InverseProperty("Salarystructure")]
    public virtual ICollection<PayrollSalarystructureDeductionformula> PayrollSalarystructureDeductionformulas { get; set; } = new List<PayrollSalarystructureDeductionformula>();

    [InverseProperty("Salarystructure")]
    public virtual ICollection<PayrollSalarystructureExceptionformula> PayrollSalarystructureExceptionformulas { get; set; } = new List<PayrollSalarystructureExceptionformula>();

    [InverseProperty("Salarystructure")]
    public virtual ICollection<PayrollSalarystructureIncreasementformula> PayrollSalarystructureIncreasementformulas { get; set; } = new List<PayrollSalarystructureIncreasementformula>();

    [InverseProperty("Salarystructure")]
    public virtual ICollection<PayrollSalarystructureLeaveformula> PayrollSalarystructureLeaveformulas { get; set; } = new List<PayrollSalarystructureLeaveformula>();

    [InverseProperty("Salarystructure")]
    public virtual ICollection<PayrollSalarystructureOvertimeformula> PayrollSalarystructureOvertimeformulas { get; set; } = new List<PayrollSalarystructureOvertimeformula>();
}
