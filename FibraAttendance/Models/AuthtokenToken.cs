using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("authtoken_token")]
[Index("UserId", Name = "UQ__authtoke__B9BE370E42CB8CE4", IsUnique = true)]
public partial class AuthtokenToken
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
    [InverseProperty("AuthtokenToken")]
    public virtual AuthUser User { get; set; } = null!;
}
