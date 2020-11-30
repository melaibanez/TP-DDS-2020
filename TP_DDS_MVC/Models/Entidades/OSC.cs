using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_DDS_MVC.Models.Entidades
{
    public class OSC : TipoOrganizacion
    {
        public OSC() { }

        public OSC(string actividad) : base(actividad) { }

    }
}