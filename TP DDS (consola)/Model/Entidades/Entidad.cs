using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using TP_DDS__consola_.Model.Compras;
using TP_DDS__consola_.Model.Ingresos;

namespace TP_DDS__consola_.Model.Entidades
{
    public abstract class Entidad
    {
        public int idEntidad { get; set; }
        public string nombreFicticio { get; set; }
        public List<Compra> comprasRealizadas { get; set; }
        public List<Ingreso> ingresos { get; set; }
        public List<Criterio> criterios { get; set; }

        public Entidad (string nombreFicticio)
        {
            this.nombreFicticio = nombreFicticio;
            this.comprasRealizadas = new List<Compra>();
        }
    }
}
