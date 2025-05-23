using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_attreportsetting")]
public partial class AttAttreportsetting
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("resign_emp")]
    public short ResignEmp { get; set; }

    [Column("short_date")]
    public short ShortDate { get; set; }

    [Column("short_time")]
    public short ShortTime { get; set; }

    [Column("func_key")]
    public string? FuncKey { get; set; }

    [Column("att_item")]
    public string? AttItem { get; set; }
}
