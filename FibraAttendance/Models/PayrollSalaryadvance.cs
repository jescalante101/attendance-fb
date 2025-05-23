using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("payroll_salaryadvance")]
[Index("EmployeeId", Name = "payroll_salaryadvance_employee_id_2abd43e5")]
public partial class PayrollSalaryadvance
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("advance_amount")]
    public double AdvanceAmount { get; set; }

    [Column("advance_time", TypeName = "datetime")]
    public DateTime AdvanceTime { get; set; }

    [Column("advance_remark")]
    [StringLength(300)]
    public string? AdvanceRemark { get; set; }

    [Column("employee_id")]
    public int? EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("PayrollSalaryadvances")]
    public virtual PersonnelEmployee? Employee { get; set; }
}
