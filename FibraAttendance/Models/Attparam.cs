using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("attparam")]
[Index("Paraname", "Paratype", Name = "attparam_paraname_paratype_6f176d25_uniq", IsUnique = true)]
public partial class Attparam
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("paraname")]
    [StringLength(30)]
    public string Paraname { get; set; } = null!;

    [Column("paratype")]
    [StringLength(10)]
    public string? Paratype { get; set; }

    [Column("paravalue")]
    [StringLength(250)]
    public string? Paravalue { get; set; }
}
