using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("auth_user_profile")]
[Index("UserId", Name = "UQ__auth_use__B9BE370EE3EA0807", IsUnique = true)]
public partial class AuthUserProfile
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("login_name")]
    [StringLength(30)]
    public string LoginName { get; set; } = null!;

    [Column("pin_tabs")]
    public string PinTabs { get; set; } = null!;

    [Column("disabled_fields")]
    public string DisabledFields { get; set; } = null!;

    [Column("column_order")]
    public string ColumnOrder { get; set; } = null!;

    [Column("preferences")]
    public string Preferences { get; set; } = null!;

    [Column("user_id")]
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("AuthUserProfile")]
    public virtual AuthUser User { get; set; } = null!;
}
