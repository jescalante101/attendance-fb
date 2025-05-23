using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("payroll_reimbursement")]
[Index("EmployeeId", Name = "payroll_reimbursement_employee_id_c4bbde36")]
public partial class PayrollReimbursement
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("rmb_amount")]
    public double RmbAmount { get; set; }

    [Column("rmb_time", TypeName = "datetime")]
    public DateTime RmbTime { get; set; }

    [Column("rmb_file")]
    [StringLength(200)]
    public string? RmbFile { get; set; }

    [Column("rmb_remark")]
    [StringLength(300)]
    public string? RmbRemark { get; set; }

    [Column("employee_id")]
    public int? EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("PayrollReimbursements")]
    public virtual PersonnelEmployee? Employee { get; set; }
}
