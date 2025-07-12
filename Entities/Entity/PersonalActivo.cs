using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entity.Scire;

namespace Entities.Entity
{
    [Table("Personal_activo")]
    public class PersonalActivo
    {

        [Column("Personal_Id")]
        public string PersonalId { get; set; }

        [Column("Categoria_Auxiliar_Id")]
        public string CategoriaAuxiliarId { get; set; }

        // Relación inversa
        [ForeignKey("PersonalId")]
        public virtual PersonalEntity Personal { get; set; }

        [ForeignKey("CategoriaAuxiliarId")]
        public virtual CategoriaAuxiliar CategoriaAuxiliar { get; set; }
    }
}
