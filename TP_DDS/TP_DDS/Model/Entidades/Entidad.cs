using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Compras;
using TP_DDS.Model.Ingresos;

namespace TP_DDS.Model.Entidades
{
    public abstract class Entidad
    {
        [Key]
        [Column("idEntidad")]
        public int idEntidad { get; set; }

        [Column("nombreFicticio")]
        public string nombreFicticio { get; set; }
        public List<Compra> comprasRealizadas { get; set; }
        public List<Ingreso> ingresos { get; set; }
        public List<Criterio> criterios { get; set; }

        public Entidad(string nombreFicticio)
        {
            this.nombreFicticio = nombreFicticio;
            this.comprasRealizadas = new List<Compra>();
        }

        public List<Compra> GetComprasSinIngresoAsignado()
        {
            return comprasRealizadas.FindAll(compra => compra.egreso.TieneIngresoAsociado() != true);
        }

        public List<Ingreso> GetIngresosDispobibles()
        {
            return ingresos.FindAll(ingreso => !ingreso.EgresosTotalizanMonto());
        }
    }
}
