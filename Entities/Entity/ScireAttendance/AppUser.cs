using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entity.ScireAttendance
{
    [Table("AppUser")]
    public class AppUser
    {
        [Key]
        [Column("userId")]
        public int UserId { get; set; }

        [Column("userName")]
        [StringLength(50)]
        public string UserName { get; set; }
    }
}
