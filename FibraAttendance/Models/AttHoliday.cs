using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_holiday")]
[Index("DepartmentId", Name = "att_holiday_department_id_fbbbd185")]
public partial class AttHoliday
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("alias")]
    [StringLength(50)]
    public string Alias { get; set; } = null!;

    [Column("start_date", TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column("duration_day")]
    public short DurationDay { get; set; }

    [Column("work_type")]
    public short WorkType { get; set; }

    [Column("department_id")]
    public int? DepartmentId { get; set; }

    [Column("overtime_lv1")]
    public short OvertimeLv1 { get; set; }

    [Column("overtime_lv2")]
    public short OvertimeLv2 { get; set; }

    [Column("overtime_lv3")]
    public short OvertimeLv3 { get; set; }

    [InverseProperty("Holiday")]
    public virtual ICollection<AccAccholiday> AccAccholidays { get; set; } = new List<AccAccholiday>();

    [ForeignKey("DepartmentId")]
    [InverseProperty("AttHolidays")]
    public virtual PersonnelDepartment? Department { get; set; }
}
