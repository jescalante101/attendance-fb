using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("payroll_extraincrease")]
[Index("EmployeeId", Name = "payroll_extraincrease_employee_id_f902e6bb")]
public partial class PayrollExtraincrease
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

    [Column("amount")]
    public double Amount { get; set; }

    [Column("issued_time", TypeName = "datetime")]
    public DateTime IssuedTime { get; set; }

    [Column("remark")]
    [StringLength(300)]
    public string? Remark { get; set; }

    [Column("employee_id")]
    public int? EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("PayrollExtraincreases")]
    public virtual PersonnelEmployee? Employee { get; set; }
}
