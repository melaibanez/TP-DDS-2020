using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Models.Ingresos;
using TP_DDS_MVC.Models.Proyectos;

namespace TP_DDS_MVC.Models.Entidades
{
    [Table("entidades")]
    public abstract class Entidad
    {
        [Key]
        public int idEntidad { get; set; }

        [StringLength(50)]
        public string nombreFicticio { get; set; }
        public List<Compra> comprasRealizadas { get; set; }
        public List<Ingreso> ingresos { get; set; }
        public List<Criterio> criterios { get; set; }
        public List<DocumentoComercial> documentosComerciales { get; set; }
        public List<Egreso> egresos { get; set; }
        public List<Operacion> Operaciones { get; set; }

        public Entidad() { }

        public Entidad(string nombreFicticio)
        {
            this.nombreFicticio = nombreFicticio;
            this.comprasRealizadas = new List<Compra>();
            this.ingresos = new List<Ingreso>();
        }

        public List<Compra> GetComprasSinIngresoAsignado()
        {
            return comprasRealizadas.FindAll(compra => !compra.egreso.tieneIngresoAsociado());
        }

        public List<Egreso> getEgresosSinVincular()
        {
            return egresos.Where(egre => !egre.tieneIngresoAsociado()).ToList();
        }

        public List<Ingreso> GetIngresosDisponibles()
        {
            return ingresos.FindAll(ingreso => ingreso.EgresosNoTotalizanMonto());
        }

        public void AgregarCompra(Compra compra)
        {
            comprasRealizadas.Add(compra);
        }

        public void AgregarIngreso(Ingreso ingreso)
        {
            ingresos.Add(ingreso);

        }

        public void AgregarOperacion(Operacion unaOperacion)
        {
            this.Operaciones.Add(unaOperacion);
        }

    }
}