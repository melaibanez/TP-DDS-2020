using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP_DDS_MVC.Models.Entidades;

namespace TP_DDS_MVC.Models.Proyectos
{
    class Operacion
    {
        public string tipoOperacion { get; set; }
        public ProyectoFinanciamiento proyecto;
        public Entidad entidad { get; set; }
    }
}