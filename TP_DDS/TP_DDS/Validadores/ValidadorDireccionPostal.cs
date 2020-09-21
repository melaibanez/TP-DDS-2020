using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Model.Entidades;
using Newtonsoft.Json.Linq;

namespace TP_DDS.Validadores
{
    class ValidadorDireccionPostal
    {

        public static bool validarDireccionPostal(DireccionPostal dirPos)
        {
            validarPais(dirPos);
            return true;
        }

        public static bool validarPais(DireccionPostal dirPos)
        {
            var client = new RestClient("https://api.mercadolibre.com/");
            var request = new RestRequest("classified_locations/countries/");
            request.RequestFormat = DataFormat.Json;
            var response = client.Get(request).Content;
            dynamic stuff = JObject.Parse(response);
            return true;

        }
    }
}
