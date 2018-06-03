using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace scanner.cuerpos
{
    class restClient
    {
         HttpClient client;
        
        public restClient() {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 2500;
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("Content-type", "application/json");
            //client.BaseAddress = new Uri("http://192.168.1.70:3000/orden");
        }
        
        public string inserUser()
        {
            itemUsuario codigo = new itemUsuario
            {
                user = ""
            };
            string json = JsonConvert.SerializeObject(codigo, Formatting.Indented);
            StringContent Content = new StringContent(json, Encoding.UTF8, "application/json");
            Uri RequestUri = new Uri("https://usuarioapp.herokuapp.com/codigo");
            HttpResponseMessage res = client.PutAsync(RequestUri, Content).Result;
            string result = JsonConvert.SerializeObject(res.Content.ReadAsStringAsync().Result, Formatting.Indented);
            var find = JsonConvert.DeserializeObject<itemUsuario>(res.Content.ReadAsStringAsync().Result);
            return find.user;
        }
    }
}
