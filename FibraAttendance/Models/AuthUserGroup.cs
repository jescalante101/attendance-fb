using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("auth_user_groups")]
[Index("GroupId", Name = "auth_user_groups_group_id_97559544")]
[Index("MyuserId", Name = "auth_user_groups_myuser_id_d03e8dcc")]
[Index("MyuserId", "GroupId", Name = "auth_user_groups_myuser_id_group_id_664bdfc3_uniq", IsUnique = true)]
public partial class AuthUserGroup
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("myuser_id")]
    public int MyuserId { get; set; }

    [Column("group_id")]
    public int GroupId { get; set; }

    [ForeignKey("GroupId")]
    [InverseProperty("AuthUserGroups")]
    public virtual AuthGroup Group { get; set; } = null!;

    [ForeignKey("MyuserId")]
    [InverseProperty("AuthUserGroups")]
    public virtual AuthUser Myuser { get; set; } = null!;
}
