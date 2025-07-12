using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entity.Scire
{
    [Table("Categoria_Auxiliar")]
    public class CategoriaAuxiliar
    {
        [Key]
        [Column("Categoria_Auxiliar_Id")]
        public string CategoriaAuxiliarId { get; set; }

        [Column("Descripcion")]
        public string Descripcion { get; set; }

        [Column("Compania_Id")]
        public string CompaniaId { get; set; }

        [Column("Codigo_Auxiliar")]
        public string CodigoAuxiliar { get; set; }
        public virtual ICollection<PersonalActivo> PersonalActivos { get; set; }

    }
}
