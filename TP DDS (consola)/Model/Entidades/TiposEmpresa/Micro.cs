using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_.Model.Entidades.TiposEmpresa
{
    class Micro : Empresa
    {
        public Micro(string actividad, string sector, float promVentas, int cantPersonal) : base(actividad, sector, promVentas, cantPersonal) { }
    }
}
