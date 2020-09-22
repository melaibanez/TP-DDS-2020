using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Compras;
using TP_DDS.Model.Ingresos;

namespace TP_DDS.Model.Entidades
{
    [Table("entidades")]
    public abstract class Entidad
    {
        [Key]
        public int idEntidad { get; set; }

        [StringLength(50)]
        public string nombreFicticio { get; set; }
        public List<Compra> comprasRealizadas { get; set; }
        public List<Ingreso> ingresos { get; set; }
        public List<Criterio> criterios { get; set; }

        public Entidad() { }

        public Entidad(string nombreFicticio)
        {
            this.nombreFicticio = nombreFicticio;
            this.comprasRealizadas = new List<Compra>();
            this.ingresos = new List<Ingreso>();
        }

        public List<Compra> GetComprasSinIngresoAsignado()
        {
            return comprasRealizadas.FindAll(compra => !compra.egreso.tieneIngresoAsociado());
        }

        public List<Ingreso> GetIngresosDisponibles()
        {
            return ingresos.FindAll(ingreso => ingreso.EgresosNoTotalizanMonto());
        }

        public void AgregarCompra(Compra compra)
        {
            comprasRealizadas.Add(compra);
        }

        public void AgregarIngreso(Ingreso ingreso)
        {
            ingresos.Add(ingreso);

        }
    }
}
