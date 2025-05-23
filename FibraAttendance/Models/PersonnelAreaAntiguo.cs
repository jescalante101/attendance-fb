using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Keyless]
[Table("personnel_area_ANTIGUO")]
public partial class PersonnelAreaAntiguo
{
    [Column("id")]
    public int Id { get; set; }

    [Column("area_code")]
    [StringLength(30)]
    public string AreaCode { get; set; } = null!;

    [Column("area_name")]
    [StringLength(30)]
    public string AreaName { get; set; } = null!;

    [Column("is_default")]
    public bool IsDefault { get; set; }

    [Column("parent_area_id")]
    public int? ParentAreaId { get; set; }
}
