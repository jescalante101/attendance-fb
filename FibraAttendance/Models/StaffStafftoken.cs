using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("staff_stafftoken")]
[Index("UserId", Name = "UQ__staff_st__B9BE370E26E6B3E1", IsUnique = true)]
public partial class StaffStafftoken
{
    [Key]
    [Column("key")]
    [StringLength(40)]
    public string Key { get; set; } = null!;

    [Column("created", TypeName = "datetime")]
    public DateTime Created { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("StaffStafftoken")]
    public virtual PersonnelEmployee User { get; set; } = null!;
}
