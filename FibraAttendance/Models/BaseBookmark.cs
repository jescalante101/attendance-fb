using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("base_bookmark")]
[Index("ContentTypeId", Name = "base_bookmark_content_type_id_b6a0e799")]
[Index("UserId", Name = "base_bookmark_user_id_5f2d5ca2")]
public partial class BaseBookmark
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    [StringLength(128)]
    public string Title { get; set; } = null!;

    [Column("filters")]
    [StringLength(1000)]
    public string Filters { get; set; } = null!;

    [Column("is_share")]
    public bool IsShare { get; set; }

    [Column("time_saved", TypeName = "datetime")]
    public DateTime TimeSaved { get; set; }

    [Column("content_type_id")]
    public int ContentTypeId { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [ForeignKey("ContentTypeId")]
    [InverseProperty("BaseBookmarks")]
    public virtual DjangoContentType ContentType { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("BaseBookmarks")]
    public virtual AuthUser? User { get; set; }
}
