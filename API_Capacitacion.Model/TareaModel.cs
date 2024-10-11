using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Capacitacion.Model
{
    public class TareaModel
    {
        public int idTarea {  get; set; }

        public string tarea { get; set; }

        public string descripcion { get; set; }

        public bool completada { get; set; }

        public UserModel Usuario { get; set; }
    }
}
