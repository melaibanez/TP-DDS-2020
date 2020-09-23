using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS.Otros;

namespace TP_DDS.DB
{
    public static class PersistenciaDireccionPostal
    {

        public static void persistirDatosAPI()
        {
            using (MyDBContext context = new MyDBContext())
            {
                var client = new RestClient("https://api.mercadolibre.com/");

                var request = new RestRequest("classified_locations/countries/");
                request.RequestFormat = DataFormat.Json;
                var response = client.Get(request).Content;
                dynamic countries = JArray.Parse(response);

                Console.WriteLine(countries[0].name);
                Pais pais = new Pais();
                pais.nombre = countries[0].name;
                pais.id = countries[0].id;
                pais.idMoneda = countries[0].currency_id;
                context.Paises.Add(pais);

                var requestProv = new RestRequest("classified_locations/countries/" + pais.id);
                requestProv.RequestFormat = DataFormat.Json;
                var responseProv = client.Get(requestProv).Content;
                dynamic paisDinam = JObject.Parse(responseProv);

                for (int j = 0; j < paisDinam.states.Count; j++)
                {
                    Console.WriteLine("    " + paisDinam.states[j].name);
                    Provincia prov = new Provincia();
                    prov.id = paisDinam.states[j].id;
                    prov.nombre = paisDinam.states[j].name;
                    prov.idPais = pais.id;
                    context.Provincias.Add(prov);

                    var requestCiu = new RestRequest("classified_locations/states/" + prov.id);
                    requestCiu.RequestFormat = DataFormat.Json;
                    var responseCiu = client.Get(requestCiu).Content;
                    dynamic provDinam = JObject.Parse(responseCiu);

                    for (int k = 0; k < provDinam.cities.Count; k++)
                    {
                        Console.WriteLine("        " + provDinam.cities[k].name);
                        Ciudad ciudad = new Ciudad();
                        ciudad.id = provDinam.cities[k].id;
                        ciudad.nombre = provDinam.cities[k].name;
                        ciudad.idProvincia = prov.id;
                        context.Ciudades.Add(ciudad);
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
