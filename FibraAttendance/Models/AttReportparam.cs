using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("att_reportparam")]
public partial class AttReportparam
{
    [Key]
    [Column("param_name")]
    [StringLength(20)]
    public string ParamName { get; set; } = null!;

    [Column("param_value")]
    public string ParamValue { get; set; } = null!;
}
