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

                dynamic mediosDePago;
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.mercadopago.com/sites/MLA/payment_methods?marketplace=NONE"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer TEST-4212134067967201-121621-9de28914fec4d471ecf9661af1713d7d-264924399");

                        var response = httpClient.SendAsync(request);

                        mediosDePago = response.ToString();
                    }
                }


                if (context.TiposMediosDePago.Count() == 0)
                {
                    //var client = new RestClient("https://api.mercadopago.com");

                   // var request = new RestRequest("v1/payment_methods");
                    //request.RequestFormat = DataFormat.Json;
                   // var response = client.Get(request).Content;
                    //dynamic mediosDePago = JArray.Parse(response);


                    for(int i=0; i< mediosDePago.Count; i++)
                    {
                        TipoMedioDePago medioDePago = new TipoMedioDePago();
                        medioDePago.id = mediosDePago[i].id;
                        medioDePago.name = mediosDePago[i].name;
                        medioDePago.payment_type_id = mediosDePago[i].payment_type_id;
                        medioDePago.status = mediosDePago[i].status;
                        medioDePago.deferred_capture = mediosDePago[i].deferred_capture;

                        context.TiposMediosDePago.Add(medioDePago);

                    }

                    
                }


            }


        }

    }
}