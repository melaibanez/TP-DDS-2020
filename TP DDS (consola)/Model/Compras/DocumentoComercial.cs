using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_
{
    public class DocumentoComercial
    {
        public int idDocComercial { get; set; }
        public  string nroIdentificacion { get; set; }
        public string tipo_enlace { get; set; }

        public DocumentoComercial(string nroIdentificacion, string tipo_enlace)
        {
            this.nroIdentificacion = nroIdentificacion;
            this.tipo_enlace = tipo_enlace;
        }

        public string getTipo_Enlace() { return tipo_enlace; }

    }
}
