using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class ResultadoConsulta<T>
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public PaginatedList<T> Data { get; set; }

    }
}
