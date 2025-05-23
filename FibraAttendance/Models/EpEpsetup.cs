using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("ep_epsetup")]
public partial class EpEpsetup
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

    [Column("temp_alarm")]
    public bool TempAlarm { get; set; }

    [Column("temp_warning", TypeName = "numeric(4, 1)")]
    public decimal TempWarning { get; set; }

    [Column("temp_unit")]
    public short TempUnit { get; set; }

    [Column("mask_alarm")]
    public bool MaskAlarm { get; set; }
}
