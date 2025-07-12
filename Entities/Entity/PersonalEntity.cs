using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity
{
    [Table("Personal")]
    public class PersonalEntity
    {
        [Key]
        [Column("Personal_Id")]
        public string PersonalId { get; set; }
        [Column("Apellido_Paterno")]
        public string ApellidoPaterno { get; set; }
        [Column("Apellido_Materno")]
        public string ApellidoMaterno { get; set; }
        [Column("Nombres")]
        public string Nombres { get; set; }
        [Column("Fecha_Nacimiento")]
        public DateTime? FechaNacimiento { get; set; }
        [Column("Direccion")]
        public string Direccion { get; set; }
        [Column("Nro_Doc")]
        public string NroDoc { get; set; }
        [Column("Telefono")]
        public string Telefono { get; set; }
        [Column("Referencia")]
        public string Referencia { get; set; }

        public virtual ICollection<PersonalActivo> PersonalActivos { get; set; }
    }
}
