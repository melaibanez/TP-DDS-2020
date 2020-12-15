using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Models.Entidades;
using TP_DDS_MVC.Models.Proyectos;
using MongoDB.Bson.Serialization.Attributes;

namespace TP_DDS_MVC.Models.Ingresos
{
    [Table("ingresos")]
    public class Ingreso
    {
        [Key]
        public int idIngreso { get; set; }

        [StringLength(200)]
        public string descripcion { get; set; }

        public float monto { get; set; }

        public DateTime fechaDesde { get; set; }

        public DateTime fechaHasta { get; set; }

        [ForeignKey("entidad")]
        [BsonIgnore]
        public int idEntidad { get; set; }
        public Entidad entidad { get; set; }
        [BsonIgnore]
        public List<Egreso> egresosAsociados { get; set; }

        [ForeignKey("proyecto")]
        [BsonIgnore]
        public int? idProyecto { get; set; }
        [BsonIgnore]
        public ProyectoFinanciamiento proyecto { get; set; }

        public Ingreso() { }
        public Ingreso(string descripcion, float montoTotal, List<Egreso> egresosAsociados)
        {
            this.descripcion = descripcion;
            this.monto = montoTotal;
            this.egresosAsociados = new List<Egreso>();
            this.egresosAsociados = egresosAsociados;
        }

        public List<Egreso> getEgresoAsociado() { return egresosAsociados; }

        public void addEgresoAsociado(Egreso egreso) 
        {
            this.egresosAsociados = new List<Egreso>();
            this.egresosAsociados.Add(egreso); 
        }

        public bool EgresosNoTotalizanMonto()
        {
            return montoTotalEgresosAsociados() < monto;

        }

        public float montoTotalEgresosAsociados()
        {
            if (egresosAsociados == null) return 0;
           // List<float> montosEgresos = new List<float>();
           /// montosEgresos = egresosAsociados.Select(egreso => egreso.montoTotal).ToList();
           return egresosAsociados.Sum(egreso=>egreso.montoTotal);
           //return montosEgresos.Sum(monto => Convert.ToInt32(monto));
        }
    }
}