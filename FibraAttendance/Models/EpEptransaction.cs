using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("ep_eptransaction")]
[Index("EmpId", Name = "ep_eptransaction_emp_id_1006883f")]
[Index("EmpId", "CheckDatetime", Name = "ep_eptransaction_emp_id_check_datetime_57cec995_uniq", IsUnique = true)]
[Index("TerminalId", Name = "ep_eptransaction_terminal_id_4490b209")]
public partial class EpEptransaction
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

    [Column("area")]
    [StringLength(20)]
    public string Area { get; set; } = null!;

    [Column("check_datetime", TypeName = "datetime")]
    public DateTime? CheckDatetime { get; set; }

    [Column("check_date", TypeName = "datetime")]
    public DateTime CheckDate { get; set; }

    [Column("check_time", TypeName = "datetime")]
    public DateTime CheckTime { get; set; }

    [Column("temperature", TypeName = "numeric(4, 1)")]
    public decimal Temperature { get; set; }

    [Column("is_mask")]
    public bool IsMask { get; set; }

    [Column("upload_time", TypeName = "datetime")]
    public DateTime UploadTime { get; set; }

    [Column("source")]
    public short Source { get; set; }

    [Column("emp_id")]
    public int? EmpId { get; set; }

    [Column("terminal_id")]
    public int? TerminalId { get; set; }

    [ForeignKey("EmpId")]
    [InverseProperty("EpEptransactions")]
    public virtual PersonnelEmployee? Emp { get; set; }

    [ForeignKey("TerminalId")]
    [InverseProperty("EpEptransactions")]
    public virtual IclockTerminal? Terminal { get; set; }
}
