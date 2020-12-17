using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DDS_MVC.Models.Compras;
using TP_DDS_MVC.Helpers.DB;
using System.Net.Http;

namespace TP_DDS_MVC.Helpers.DB
{
    public class PersistenciaMoneda
    {
        public static void persistirMonedas()
        {
            using (MyDBContext context = new MyDBContext())
            {


                if (context.Moneda.Count() == 0)
                {
                    var client = new RestClient(" https://api.mercadolibre.com");

                    var request = new RestRequest("currencies/");
                    request.RequestFormat = DataFormat.Json;
                    var response = client.Get(request).Content;
                    dynamic monedas = JArray.Parse(response);


                    for (int i = 0; i < monedas.Count; i++)
                    {
                        Moneda moneda = new Moneda();
                        moneda.id = monedas[i].id;
                        moneda.description = monedas[i].description;
                        moneda.decimal_places = monedas[i].decimal_places;
                        moneda.symbol = monedas[i].symbol;

                        context.Moneda.Add(moneda);
                        
                    }
                    context.SaveChanges();

                }


            }


        }

    }
}