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
            string id_C = validarPais(dirPos);
            if (!id_C.Equals("Pais No Encontrado")){ 
                string id_S = validarProvincia(dirPos, id_C);
                if(!id_S.Equals("Provincia No Encontrada"))
                {
                   return validarCiudad(dirPos, id_S);
                }
            }
            return false;
        }

        public static string validarPais(DireccionPostal dirPos)
        {
            var client = new RestClient("https://api.mercadolibre.com/");
 
            var request = new RestRequest("classified_locations/countries/");
            request.RequestFormat = DataFormat.Json;
            var response = client.Get(request).Content;
            dynamic countries = JArray.Parse(response);
            string paisComparado = dirPos.pais;
            int cantidadPaises = countries.Count;
            for (int i = 0; i < cantidadPaises; i++)
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

        public static string validarProvincia(DireccionPostal dirPos, string id_C)
        {
            var client = new RestClient("https://api.mercadolibre.com/");

            var request = new RestRequest("classified_locations/countries/" + id_C);
            request.RequestFormat = DataFormat.Json;
            var response = client.Get(request).Content;
            dynamic states = JArray.Parse(response);
            string stateComparado = dirPos.provincia;
            int cantidadProvincias = states.Count;
            for(int i = 0; i < cantidadProvincias; i++)
            {
                if (states[i].name == stateComparado)
                {
                    return states[i].id;
                }
            }
            return "Provincia No Encontrada";


        }

        public static bool validarCiudad(DireccionPostal dirPos, string id_S)
        {
            var client = new RestClient("https://api.mercadolibre.com/");

            var request = new RestRequest("classified_locations/countries/states/" + id_S);
            request.RequestFormat = DataFormat.Json;
            var response = client.Get(request).Content;
            dynamic cities = JArray.Parse(response);
            string citieComparada = dirPos.ciudad;
            int cantidadCiudades = cities.Count;
            for (int i = 0; i < cantidadCiudades; i++)
            {
                if (cities[i].name == citieComparada)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
