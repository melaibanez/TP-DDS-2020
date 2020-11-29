using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Entidades;

namespace TP_DDS.Model.Proyectos
{
    class Operacion
    {
        public string tipoOperacion { get; set; }
        public ProyectoFinanciamiento proyecto;
        public Entidad entidad { get; set; }
    }
}
