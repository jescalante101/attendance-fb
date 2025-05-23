using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_attcalclog")]
public partial class AttAttcalclog
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("dept_id")]
    public int? DeptId { get; set; }

    [Column("emp_id")]
    public int? EmpId { get; set; }

    [Column("start_date", TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column("end_date", TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    [Column("update_time", TypeName = "datetime")]
    public DateTime UpdateTime { get; set; }

    [Column("log_type")]
    public int LogType { get; set; }
}
