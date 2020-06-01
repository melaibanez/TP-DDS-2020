using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_DDS__consola_
{
    class Presupuesto : DocumentoComercial
    {
        private List<Item> items;
        private PrestadorDeServicios prestadorDeServicios;
        private float montoTotal;

        public Presupuesto(string nroIdentificacion, string tipo_enlace, List<Item> items, PrestadorDeServicios prestadorDeServicios):base(nroIdentificacion, tipo_enlace) {
            this.items = items;
            this.prestadorDeServicios = prestadorDeServicios;
            this.montoTotal = items.Sum(i => i.getValor() * i.getCant());
        }

        public float getMontoTotal() { return montoTotal; }
        public PrestadorDeServicios getPrestadorDeServicios() { return prestadorDeServicios; }
        public List<Item> getItems() { return items; }
    }
}
