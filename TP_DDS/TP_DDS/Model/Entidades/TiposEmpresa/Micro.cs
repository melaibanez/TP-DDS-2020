using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Entidades.TiposEmpresa
{
    public class Micro : Empresa
    {
        public Micro(string actividad, string sector, float promVentas, int cantPersonal) : base(actividad, sector, promVentas, cantPersonal) { }
    }
}
