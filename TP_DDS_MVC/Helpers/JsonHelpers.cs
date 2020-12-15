using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Models.Entidades;

namespace TP_DDS_MVC.Helpers
{
    public class JsonEgreso
    {
        public Egreso egreso { get; set; }
        public string[] docsComerciales { get; set; }
    }
    public class JsonIngreso
    {
        public string descripcion { get; set; }
        public int monto { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
    }
    public class JsonCompra
    {
        public Compra compra { get; set; }
        public List<int> revisores { get; set; }

    }

    public class JsonPresupuesto
    {
        public Presupuesto presupuesto { get; set; }
        public bool setEgreso { get; set; }
    }

    public class JsonCriterio
    {
        public int idCriterio { get; set; }

    }
        
    public class JsonEntidad
    {
        public EntidadJuridica entidad { get; set; }
        public string tipoOrganizacion{ get; set; }
        public string actividad { get; set; }
        public string sector { get; set; }
        public float promVentas { get; set; }
        public int cantPersonal { get; set; }
        public int cargarBase { get; set; }
    }

    public class JsonEntidadBase
    {
        public EntidadBase entidad { get; set; }
        public string tipoOrganizacion { get; set; }
        public string actividad { get; set; }
        public string sector { get; set; }
        public float promVentas { get; set; }
        public int cantPersonal { get; set; }
    }
}