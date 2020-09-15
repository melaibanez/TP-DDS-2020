using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP_DDS__consola_.Model.Entidades;

namespace TP_DDS__consola_.Model.Compras
{
    public class Presupuesto : DocumentoComercial
    {
        public int idPresupuesto { get; set; }
        public Entidad entidad { get; set; }
        public DateTime fechaEgreso { get; set; }
        public MedioDePago medioDePago { get; set; }
        public List<Item> items { get; set; }
        public PrestadorDeServicios prestadorDeServicios { get; set; }
        public float montoTotal { get; set; }

        public Presupuesto(string nroIdentificacion, string tipo_enlace, List<Item> items, PrestadorDeServicios prestadorDeServicios):base(nroIdentificacion, tipo_enlace) {
            this.items = items;
            this.prestadorDeServicios = prestadorDeServicios;
            this.montoTotal = items.Sum(i => i.getValor() * i.getCant());
        }

        public List<Item> getItems() { return items; }
    }
}
