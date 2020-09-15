using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DDS__consola_.Model.Compras
{
    public class Item
    {
        public int idItem { get; set; }
        public int cant { get; set; }
        public string descripcion { get; set; }
        public float valor { get; set; }
        public Categoria categorias { get; set; }

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
