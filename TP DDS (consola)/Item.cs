using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_
{
    class Item
    {
        private int cant;
        private string descripcion;
        private float valor;

        public Item(int cant, string descripcion, float valor)
        {
            this.cant = cant;
            this.descripcion = descripcion;
            this.valor = valor;
        }

        public float getValor() { return valor; }
        public float getCant() { return cant; }

    }
}
