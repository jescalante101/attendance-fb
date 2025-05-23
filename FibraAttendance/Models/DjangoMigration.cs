using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("django_migrations")]
public partial class DjangoMigration
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("app")]
    [StringLength(255)]
    public string App { get; set; } = null!;

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("applied", TypeName = "datetime")]
    public DateTime Applied { get; set; }
}
