using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("auth_user_auth_area")]
[Index("AreaId", Name = "auth_user_auth_area_area_id_d1e54c70")]
[Index("MyuserId", Name = "auth_user_auth_area_myuser_id_5fb9a803")]
[Index("MyuserId", "AreaId", Name = "auth_user_auth_area_myuser_id_area_id_02a19d63_uniq", IsUnique = true)]
public partial class AuthUserAuthArea
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("myuser_id")]
    public int MyuserId { get; set; }

    [Column("area_id")]
    public int AreaId { get; set; }

    [ForeignKey("AreaId")]
    [InverseProperty("AuthUserAuthAreas")]
    public virtual PersonnelArea Area { get; set; } = null!;

    [ForeignKey("MyuserId")]
    [InverseProperty("AuthUserAuthAreas")]
    public virtual AuthUser Myuser { get; set; } = null!;
}
