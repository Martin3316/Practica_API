using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Capacitacion.DTO.Tarea
{
    public class CreateTareaDTO
    {
        public string tarea {  get; set; }

        public string descripcion { get; set; }

        public int IdUsuario { get; set;}
    }
}
