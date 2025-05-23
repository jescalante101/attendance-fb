using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("base_sysparam")]
[Index("ParaName", "ParaType", Name = "base_sysparam_para_name_para_type_3086789a_uniq", IsUnique = true)]
public partial class BaseSysparam
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("para_name")]
    [StringLength(30)]
    public string ParaName { get; set; } = null!;

    [Column("para_type")]
    [StringLength(10)]
    public string? ParaType { get; set; }

    [Column("para_value")]
    [StringLength(250)]
    public string? ParaValue { get; set; }
}
