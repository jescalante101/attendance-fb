using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FibraAttendance.Models;

[Table("djcelery_workerstate")]
[Index("Hostname", Name = "UQ__djcelery__DA92E433F17C2C29", IsUnique = true)]
[Index("LastHeartbeat", Name = "djcelery_workerstate_last_heartbeat_4539b544")]
public partial class DjceleryWorkerstate
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("hostname")]
    [StringLength(255)]
    public string Hostname { get; set; } = null!;

    [Column("last_heartbeat", TypeName = "datetime")]
    public DateTime? LastHeartbeat { get; set; }

    [InverseProperty("Worker")]
    public virtual ICollection<DjceleryTaskstate> DjceleryTaskstates { get; set; } = new List<DjceleryTaskstate>();
}
