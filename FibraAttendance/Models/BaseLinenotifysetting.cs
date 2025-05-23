using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("base_linenotifysetting")]
[Index("LineNotifyDeptId", Name = "base_linenotifysetting_line_notify_dept_id_0643a5ed")]
[Index("LineNotifyDeptId", "LineNotifyToken", "MessageType", Name = "base_linenotifysetting_line_notify_dept_id_line_notify_token_message_type_dd79374f_uniq", IsUnique = true)]
public partial class BaseLinenotifysetting
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("include_sub_department")]
    public int? IncludeSubDepartment { get; set; }

    [Column("line_notify_token")]
    [StringLength(200)]
    public string? LineNotifyToken { get; set; }

    [Column("message_type")]
    public int? MessageType { get; set; }

    [Column("message_head")]
    [StringLength(100)]
    public string? MessageHead { get; set; }

    [Column("message_tail")]
    [StringLength(100)]
    public string? MessageTail { get; set; }

    [Column("push_time", TypeName = "datetime")]
    public DateTime? PushTime { get; set; }

    [Column("is_valid")]
    public int? IsValid { get; set; }

    [Column("remark")]
    [StringLength(200)]
    public string? Remark { get; set; }

    [Column("line_notify_dept_id")]
    public int? LineNotifyDeptId { get; set; }

    [ForeignKey("LineNotifyDeptId")]
    [InverseProperty("BaseLinenotifysettings")]
    public virtual PersonnelDepartment? LineNotifyDept { get; set; }
}
