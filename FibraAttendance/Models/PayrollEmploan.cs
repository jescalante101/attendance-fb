using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("payroll_emploan")]
[Index("EmployeeId", Name = "payroll_emploan_employee_id_97a251ef")]
public partial class PayrollEmploan
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

    [Column("loan_amount")]
    public double LoanAmount { get; set; }

    [Column("loan_time", TypeName = "datetime")]
    public DateTime LoanTime { get; set; }

    [Column("refund_cycle")]
    public short RefundCycle { get; set; }

    [Column("per_cycle_refund")]
    public double PerCycleRefund { get; set; }

    [Column("loan_clean_time", TypeName = "datetime")]
    public DateTime? LoanCleanTime { get; set; }

    [Column("remark")]
    [StringLength(300)]
    public string? Remark { get; set; }

    [Column("employee_id")]
    public int? EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("PayrollEmploans")]
    public virtual PersonnelEmployee? Employee { get; set; }
}
