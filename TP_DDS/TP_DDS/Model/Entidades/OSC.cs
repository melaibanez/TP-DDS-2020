﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DDS.Model.Entidades
{
    public class OSC : TipoOrganizacion
    {
        [Key]
        [Column("idOrganizacion")]
        public int idOSC { get; set; }

        [Column("cantPersonal")]
        public int cantPersonal { get; set; }

        [Column("promVentasAnuales")]
        public float promVentasAnuales { get; set; }
       
        [Column("clasificacion")]
        public string clasificacion { get; set; }
        public OSC(string actividad) : base(actividad) { }

    }
}
