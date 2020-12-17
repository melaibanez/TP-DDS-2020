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
    public class PersistenciaMedioDePago
    {
        public static void persistirDatosMedioDePago()
        {
            using (MyDBContext context = new MyDBContext())
            {



                if (context.tipoMediosDePago.Count() == 0)
                {
                    var client = new RestClient("https://api.mercadopago.com");
                    client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", "TEST-4212134067967201-121621-9de28914fec4d471ecf9661af1713d7d-264924399"));
                    var request = new RestRequest("v1/payment_methods");
                    request.RequestFormat = DataFormat.Json;
                    var response = client.Get(request).Content;
                    dynamic mediosDePago = JArray.Parse(response);


                    for(int i=0; i< mediosDePago.Count; i++)
                    {
                        TipoMedioDePago medioDePago = new TipoMedioDePago();
                        medioDePago.id = mediosDePago[i].id;
                        medioDePago.name = mediosDePago[i].name;

                        context.tipoMediosDePago.Add(medioDePago);

                    }

                    

                }
                context.SaveChanges();

            }


        }

    }
}