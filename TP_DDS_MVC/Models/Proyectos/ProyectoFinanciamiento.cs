using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP_DDS_MVC.Models.Ingresos;
using TP_DDS_MVC.Models.Otros;
using TP_DDS_MVC.Models.Entidades;
using TP_DDS_MVC.Models.Compras;
using MongoDB.Bson.Serialization.Attributes;

namespace TP_DDS_MVC.Models.Proyectos
{
    [Table("proyecto_financiamiento")]
   public class ProyectoFinanciamiento

    {
        [Key]
        public int idProyecyo { get; set; }
        public string propuesta { get; set; }
        public int montoTotal { get; set; }
        public Usuario director { get; set; }
        [BsonIgnore]
        public List<Ingreso> ingresos { get; set; }
        public int limiteErrogacion { get; set; }
        public int cantidadPresupuestos { get; set; }
        public string evaluacion { get; set; }
        public string resultado { get; set; }
        public DateTime fechaEjecucion { get; set; }
        public DateTime fechaCierre { get; set; }
        [BsonIgnore]
        public List<Presupuesto> presupuestos { get; set; }

        [ForeignKey("entidad")]
        public int idEntidad { get; set; }
        public Entidad entidad { get; set; }

        public void rendirCuenta(Entidad Entidad, Ingreso ingreso) //en cuotas supongo que es 1 ingreso a la vez
        {
            if (fechaEjecucion.CompareTo(fechaCierre) <= 0 && fechaEjecucion.CompareTo(ingreso.fechaDesde) >= 0 && fechaEjecucion.CompareTo(ingreso.fechaHasta) <= 0)
            {
                ingresos.Add(ingreso);
            }
        }

    }
}