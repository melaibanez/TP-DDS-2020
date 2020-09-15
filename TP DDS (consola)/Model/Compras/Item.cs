using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_
{
    public class Item
    {
        private int cant;
        private string descripcion;
        private float valor;
        private Categoria categorias;

        public Item(int cant, string descripcion, float valor, Categoria categorias) //recibe las categorias ya anidadas abajo de la categoria raiz
        {
            this.cant = cant;
            this.descripcion = descripcion;
            this.valor = valor;
            this.categorias = categorias;
        }

        public float getValor() { return valor; }
        public float getCant() { return cant; }
    }
}
