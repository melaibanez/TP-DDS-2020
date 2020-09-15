using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_
{
    public class PrestadorDeServicios
    {
        private string direccionPostal;
        private string numDoc;
        private string razonSocial;
        private string tipoDoc;

        public PrestadorDeServicios(string direccionPostal, string razonSocial, string tipoDoc, string numDoc)
        {
            this.direccionPostal = direccionPostal;
            this.numDoc = numDoc;
            this.razonSocial = razonSocial;
            this.tipoDoc = tipoDoc;
        }

    }
}
