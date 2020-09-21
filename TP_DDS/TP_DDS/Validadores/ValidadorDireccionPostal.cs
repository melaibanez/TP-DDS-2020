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
            string id_P = validarPais(dirPos);
            if (!id_P.Equals("Pais No Encontrado")){ 
                validarProvincia(dirPos, id_P);
            }
            return true;
        }

        public static string validarPais(DireccionPostal dirPos)
        {
            var client = new RestClient("https://api.mercadolibre.com/");
 
            var request = new RestRequest("classified_locations/countries/");
            request.RequestFormat = DataFormat.Json;
            var response = client.Get(request).Content;
            dynamic countries = JArray.Parse(response);
            string paisComparado = "Uruguay";//dirPos.pais;
            int i;
            int cantidadPaises = countries.Count;
            for (i = 0; i < cantidadPaises; i++)
            {
                //Console.WriteLine(countries[i].name);
                if (countries[i].name == paisComparado)
                {
                    //Console.WriteLine(countries[i].id);
                    return countries[i].id;
                }
            }
            return "Pais No Encontrado";

        }

        public static string validarProvincia(DireccionPostal dirPos, string id_P)
        {
            var client = new RestClient("https://api.mercadolibre.com/");

            var request = new RestRequest("classified_locations/countries/" + id_P);
            request.RequestFormat = DataFormat.Json;
            var response = client.Get(request).Content;
            dynamic states = JArray.Parse(response);



        }
    }
}
