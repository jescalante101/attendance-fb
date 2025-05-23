using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("payroll_monthlysalary")]
[Index("EmployeeId", Name = "payroll_monthlysalary_employee_id_97fdc6a9")]
public partial class PayrollMonthlysalary
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("calc_time", TypeName = "datetime")]
    public DateTime? CalcTime { get; set; }

    [Column("basic_salary")]
    public double? BasicSalary { get; set; }

    [Column("effective_date", TypeName = "datetime")]
    public DateTime? EffectiveDate { get; set; }

    [Column("format_dict")]
    public string? FormatDict { get; set; }

    [Column("ot1")]
    public double? Ot1 { get; set; }

    [Column("ot2")]
    public double? Ot2 { get; set; }

    [Column("ot3")]
    public double? Ot3 { get; set; }

    [Column("normal_ot")]
    public double? NormalOt { get; set; }

    [Column("weekend_ot")]
    public double? WeekendOt { get; set; }

    [Column("holiday_ot")]
    public double? HolidayOt { get; set; }

    [Column("late_time")]
    public double? LateTime { get; set; }

    [Column("early_leave")]
    public double? EarlyLeave { get; set; }

    [Column("absent_time")]
    public double? AbsentTime { get; set; }

    [Column("increase")]
    public double? Increase { get; set; }

    [Column("deduction")]
    public double? Deduction { get; set; }

    [Column("leave")]
    public string? Leave { get; set; }

    [Column("ot1_formula")]
    public string? Ot1Formula { get; set; }

    [Column("ot2_formula")]
    public string? Ot2Formula { get; set; }

    [Column("ot3_formula")]
    public string? Ot3Formula { get; set; }

    [Column("normal_ot_formula")]
    public string? NormalOtFormula { get; set; }

    [Column("weekend_ot_formula")]
    public string? WeekendOtFormula { get; set; }

    [Column("holiday_ot_formula")]
    public string? HolidayOtFormula { get; set; }

    [Column("late_time_formula")]
    public string? LateTimeFormula { get; set; }

    [Column("early_leave_formula")]
    public string? EarlyLeaveFormula { get; set; }

    [Column("absent_time_formula")]
    public string? AbsentTimeFormula { get; set; }

    [Column("increase_formula")]
    public string? IncreaseFormula { get; set; }

    [Column("deduction_formula")]
    public string? DeductionFormula { get; set; }

    [Column("leave_formula")]
    public string? LeaveFormula { get; set; }

    [Column("ot1_formula_name")]
    public string? Ot1FormulaName { get; set; }

    [Column("ot2_formula_name")]
    public string? Ot2FormulaName { get; set; }

    [Column("ot3_formula_name")]
    public string? Ot3FormulaName { get; set; }

    [Column("normal_ot_formula_name")]
    public string? NormalOtFormulaName { get; set; }

    [Column("weekend_ot_formula_name")]
    public string? WeekendOtFormulaName { get; set; }

    [Column("holiday_ot_formula_name")]
    public string? HolidayOtFormulaName { get; set; }

    [Column("late_time_formula_name")]
    public string? LateTimeFormulaName { get; set; }

    [Column("early_leave_formula_name")]
    public string? EarlyLeaveFormulaName { get; set; }

    [Column("absent_time_formula_name")]
    public string? AbsentTimeFormulaName { get; set; }

    [Column("increase_formula_name")]
    public string? IncreaseFormulaName { get; set; }

    [Column("deduction_formula_name")]
    public string? DeductionFormulaName { get; set; }

    [Column("leave_formula_name")]
    public string? LeaveFormulaName { get; set; }

    [Column("extra_increase")]
    public double? ExtraIncrease { get; set; }

    [Column("extra_deduction")]
    public double? ExtraDeduction { get; set; }

    [Column("total_loan_amount")]
    public double? TotalLoanAmount { get; set; }

    [Column("refund_loan_amount")]
    public double? RefundLoanAmount { get; set; }

    [Column("unrefund_loan_amount")]
    public double? UnrefundLoanAmount { get; set; }

    [Column("loan_deduction")]
    public double? LoanDeduction { get; set; }

    [Column("loan_increase")]
    public double? LoanIncrease { get; set; }

    [Column("advance_increase")]
    public double? AdvanceIncrease { get; set; }

    [Column("advance_deduction")]
    public double? AdvanceDeduction { get; set; }

    [Column("reimbursement")]
    public double? Reimbursement { get; set; }

    [Column("total_increase_formula")]
    public string? TotalIncreaseFormula { get; set; }

    [Column("total_increase_formula_name")]
    public string? TotalIncreaseFormulaName { get; set; }

    [Column("total_increase_expression")]
    public string? TotalIncreaseExpression { get; set; }

    [Column("total_increase")]
    public double? TotalIncrease { get; set; }

    [Column("total_deduction_formula")]
    public string? TotalDeductionFormula { get; set; }

    [Column("total_deduction_formula_name")]
    public string? TotalDeductionFormulaName { get; set; }

    [Column("total_deduction_expression")]
    public string? TotalDeductionExpression { get; set; }

    [Column("total_deduction")]
    public double? TotalDeduction { get; set; }

    [Column("total_salary_expression")]
    public string? TotalSalaryExpression { get; set; }

    [Column("total_salary")]
    public double? TotalSalary { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("PayrollMonthlysalaries")]
    public virtual PersonnelEmployee Employee { get; set; } = null!;
}
