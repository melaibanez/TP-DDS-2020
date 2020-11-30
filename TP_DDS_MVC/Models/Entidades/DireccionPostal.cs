using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_DDS_MVC.Models.Entidades
{
    [Table("direcciones_postales")]
    public class DireccionPostal
    {
        [Key]
        public int idDireccionPostal { get; set; }

        [StringLength(50)]
        public string calle { get; set; }
        [StringLength(6)]
        public string numero { get; set; }
        [StringLength(20)]
        public string piso_depto { get; set; }
        [StringLength(50)]
        public string ciudad { get; set; }
        [StringLength(50)]
        public string provincia { get; set; }
        [StringLength(50)]
        public string pais { get; set; }

        public DireccionPostal() { }

        public DireccionPostal(string calle, string numero, string piso_depto, string ciudad, string provincia, string pais)
        {
            this.calle = calle;
            this.numero = numero;
            this.piso_depto = piso_depto;
            this.ciudad = ciudad;
            this.provincia = provincia;
            this.pais = pais;
        }


    }
}