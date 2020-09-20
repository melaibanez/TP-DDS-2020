using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Entidades;

namespace TP_DDS.Model.Compras
{
    public class Presupuesto : DocumentoComercial
    {
        [Key]
        [Column("idPresupuesto")]
        public int idPresupuesto { get; set; }

        [Column("idEntidad")?]
        public int idEntidad { get; set; }
        public Entidad entidad { get; set; }

        [Column("fechaEgreso")?]
        public int idFechaEgreso { get; set; }
        public DateTime fechaEgreso { get; set; }

        [Column("idMedioDePago")?]
        public int idMedioDePago { get; set; }
        public MedioDePago medioDePago { get; set; }

        [Column("idItem")?]
        public int idItem { get; set; }
        public List<Item> items { get; set; }

        [Column("idPrestadorDeServicios")]
        public int idPrestadorDeServicios { get; set; }
        public PrestadorDeServicios prestadorDeServicios { get; set; }

        [Column("montoTotal")]
        public float montoTotal { get; set; }

        public Presupuesto(string nroIdentificacion, string tipo_enlace, List<Item> items, PrestadorDeServicios prestadorDeServicios) : base(nroIdentificacion, tipo_enlace)
        {
            this.items = items;
            this.prestadorDeServicios = prestadorDeServicios;
            this.montoTotal = items.Sum(i => i.valor * i.cant);
        }

    }
}
