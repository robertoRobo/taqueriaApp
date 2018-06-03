using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using taqueria.cuerpos;
using taqueria.ViewModel;

namespace scanner.cuerpos
{
    class restClient
    {
         HttpClient client;
        List<orden> find;
        public restClient() {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 2500;
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("Content-type", "application/json");
            //client.BaseAddress = new Uri("http://192.168.1.70:3000/orden");
        }
        public List<orden> getOrden(string usuario)
        {
            itemUsuario codigo = new itemUsuario
            {
                idUsuario = usuario
            };
            string json = JsonConvert.SerializeObject(codigo, Formatting.Indented);
            StringContent Content = new StringContent(json, Encoding.UTF8, "application/json");
            Uri RequestUri = new Uri("https://ordenesrealizadas.herokuapp.com/ordenes");
            HttpResponseMessage res = client.PutAsync(RequestUri, Content).Result;
            string result = JsonConvert.SerializeObject(res.Content.ReadAsStringAsync().Result, Formatting.Indented);
            if (result.Contains("exists"))
            {
                //result = "contiene";
                find = null;
            }
            else {
                //result = "no contiene";
                find = JsonConvert.DeserializeObject<List<orden>>(res.Content.ReadAsStringAsync().Result);
            }
            return  find;
        }
        public void insertOrden(string usuario,int sucursal,string descripcion,int total)
        {
            registro codigo = new registro
            {
                id_usu = usuario,
                sucursal = sucursal,
                desc = descripcion,
                tot = total
            };
            string json = JsonConvert.SerializeObject(codigo, Formatting.Indented);
            StringContent Content = new StringContent(json, Encoding.UTF8, "application/json");
            Uri RequestUri = new Uri("https://generadorcodigos.herokuapp.com/codigo");
            HttpResponseMessage res = client.PutAsync(RequestUri, Content).Result;
            /*string result = JsonConvert.SerializeObject(res.Content.ReadAsStringAsync().Result, Formatting.Indented);
            if (result.Contains("exists"))
            {
                //result = "contiene";
                find = null;
            }
            else
            {
                //result = "no contiene";
                find = JsonConvert.DeserializeObject<List<orden>>(res.Content.ReadAsStringAsync().Result);
            }
            return find;*/
        }

        public Boolean validaLimCompras(string usuario) {
            var clearence = new Autorizacion
            {
                idUsuario = usuario
            };

            string json = JsonConvert.SerializeObject(clearence, Formatting.Indented);
            StringContent Content = new StringContent(json, Encoding.UTF8, "application/json");
            Uri RequestUri = new Uri("https://contador-ordenes.herokuapp.com/contador");
            HttpResponseMessage res = client.PutAsync(RequestUri, Content).Result;
            Autorizacion find = JsonConvert.DeserializeObject<Autorizacion>(res.Content.ReadAsStringAsync().Result);
            return find.insertar;
        }
        public List<CarouselData> promo(string usuario)
        {
            promocion codigo = new promocion
            {
                idUsuario = usuario
            };
            List<CarouselData> promo;
            string json = JsonConvert.SerializeObject(codigo, Formatting.Indented);
            StringContent Content = new StringContent(json, Encoding.UTF8, "application/json");
            Uri RequestUri = new Uri("https://asigna-promociones.herokuapp.com/getPromociones");
            HttpResponseMessage res = client.PutAsync(RequestUri, Content).Result;
            string result = JsonConvert.SerializeObject(res.Content.ReadAsStringAsync().Result, Formatting.Indented);
            if (result.Contains("exists"))
            {
                promo = null;
            }
            else
            {
                //result = "no contiene";
                promo = JsonConvert.DeserializeObject<List<CarouselData>>(res.Content.ReadAsStringAsync().Result);
            }
            return promo;
            //return result;
        }

        public promocion insertPromo(string usuario)
        {
            promocion codigo = new promocion
            {
                idUsuario = usuario
            };
            promocion promo;
            string json = JsonConvert.SerializeObject(codigo, Formatting.Indented);
            StringContent Content = new StringContent(json, Encoding.UTF8, "application/json");
            Uri RequestUri = new Uri("https://asigna-promociones.herokuapp.com/promociones");
            HttpResponseMessage res = client.PutAsync(RequestUri, Content).Result;
            promo = JsonConvert.DeserializeObject<promocion>(res.Content.ReadAsStringAsync().Result);
            return promo;
        }
    }
}
