using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("djcelery_periodictasks")]
public partial class DjceleryPeriodictask1
{
    [Key]
    [Column("ident")]
    public short Ident { get; set; }

    [Column("last_update", TypeName = "datetime")]
    public DateTime LastUpdate { get; set; }
}
