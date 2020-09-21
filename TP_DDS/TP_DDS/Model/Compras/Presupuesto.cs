using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Entidades;

namespace TP_DDS.Model.Compras
{
  
    public class Presupuesto : DocumentoComercial
    {
        [ForeignKey("entidad")]
        public int idEntidad { get; set; }
        public Entidad entidad { get; set; }

        public DateTime fechaEgreso { get; set; }

        [ForeignKey("medioDePago")]
        public int idMedioDePago { get; set; }
        public MedioDePago medioDePago { get; set; }


        [ForeignKey("prestadorDeServicios")]
        public int idPrestadorDeServicios { get; set; }
        public PrestadorDeServicios prestadorDeServicios { get; set; }

        public float montoTotal { get; set; }

        [ForeignKey("compra")]
        public int idCompra { get; set; }
        public Compra compra { get; set; }

        public List<ItemPresupuesto> items { get; set; }

        public Presupuesto() { }

        public Presupuesto(string nroIdentificacion, string tipo_enlace, List<ItemPresupuesto> items, PrestadorDeServicios prestadorDeServicios) : base(nroIdentificacion, tipo_enlace)
        {
            this.items = items;
            this.prestadorDeServicios = prestadorDeServicios;
            this.montoTotal = items.Sum(i => i.valor * i.cant);
        }

    }
}
