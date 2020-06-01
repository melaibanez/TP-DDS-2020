using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_
{
    class DocumentoComercial
    {
        private string nroIdentificacion;
        private string tipo_enlace;

        public DocumentoComercial(string nroIdentificacion, string tipo_enlace)
        {
            this.nroIdentificacion = nroIdentificacion;
            this.tipo_enlace = tipo_enlace;
        }

        public string getTipo_Enlace() { return tipo_enlace; }

    }
}
