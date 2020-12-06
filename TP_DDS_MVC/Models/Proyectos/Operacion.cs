using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP_DDS_MVC.Models.Entidades;

namespace TP_DDS_MVC.Models.Proyectos
{
    [NotMapped]
    public class Operacion
    {
        public string tipoOperacion { get; set; }
        public string descripcion { get; set; }

        public void registrarOperacion(Entidad entidad, string tipoOperacion, string descripcion)
        {
            this.tipoOperacion = tipoOperacion;
            this.descripcion = descripcion;
            entidad.AgregarOperacion(this);

        }
    }
}