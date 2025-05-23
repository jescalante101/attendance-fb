using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("payroll_emppayrollprofile")]
[Index("EmployeeId", Name = "UQ__payroll___C52E0BA9D335899A", IsUnique = true)]
public partial class PayrollEmppayrollprofile
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("payment_mode")]
    public short? PaymentMode { get; set; }

    [Column("payment_type")]
    public short? PaymentType { get; set; }

    [Column("bank_name")]
    [StringLength(30)]
    public string? BankName { get; set; }

    [Column("bank_account")]
    [StringLength(30)]
    public string? BankAccount { get; set; }

    [Column("personnel_id")]
    [StringLength(30)]
    public string? PersonnelId { get; set; }

    [Column("agent_id")]
    [StringLength(30)]
    public string? AgentId { get; set; }

    [Column("agent_account")]
    [StringLength(30)]
    public string? AgentAccount { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("PayrollEmppayrollprofile")]
    public virtual PersonnelEmployee Employee { get; set; } = null!;
}
