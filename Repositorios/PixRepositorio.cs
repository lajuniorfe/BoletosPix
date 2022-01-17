using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SdmBoletos.Repositorios
{
    public class PixRepositorio : IPix
    {
        public string GerarCobrancaPix(string IdIdentificacao, string Token, dynamic json)
        {
            try
            {
                var client = new RestClient($"https://api.bb.com.br/pix/v1/cobqrcode/{IdIdentificacao}?gw-dev-app-key=7091308b0fffbec01368e181a0050a56b971a5b5");
                client.Timeout = -1;
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Authorization", "Bearer " + Token);
                request.AddHeader("Content-Type", "application/json");
                var body = json;
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    return response.Content.ToString();
                }
                else
                {
                    return response.Content.ToString();
                }
            }
            catch
            {
                throw;
            }
        }

        public string ConsultarCobrancaPix(string Identificacao, string Token)
        {
            try
            {
                var client = new RestClient($"https://api.hm.bb.com.br/pix/v1/cob/{Identificacao}?gw-dev-app-key=d27b37790dffabb01369e17d50050056b921a5bb");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Bearer " + Token);
                request.AddHeader("Content-Type", "application/json");

                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    return response.Content.ToString();
                }
                else
                {
                    return response.Content.ToString();
                }
            }
            catch
            {
                throw;
            }
        }

        public string ConsultarPixRecebidos(Dictionary<string, object> Parametros, string Token)
        {
            try
            {

                var client = new RestClient($"https://api.bb.com.br/pix/v1/");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddParameter("gw-dev-app-key", "7091308b0fffbec01368e181a0050a56b971a5b5");
                request.AddHeader("Authorization", "Bearer " + Token);

                List<string> Chave = new List<string>();
                List<string> Valor = new List<string>();


                foreach (var c in Parametros.Keys)
                {
                    Chave.Add(Convert.ToString(c));
                }

                foreach (var v in Parametros.Values)
                {
                    Valor.Add(Convert.ToString(v));
                }

                for (var i = 0; i < Chave.Count; i++)
                {
                    var chave = Chave[i];
                    var valor = Valor[i];

                    request.AddParameter(chave, valor);

                }
            

                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    return response.Content.ToString();
                }
                else
                {
                    return response.Content.ToString();
                }
            }
            catch
            {
                throw;
            }
        }

        public string ConsultarPixIdentificacao(string E2eid, string Token)
        {
            try
            {
                var client = new RestClient($"https://api.hm.bb.com.br/pix/v1/pix/{E2eid}");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Bearer " + Token);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("gw-dev-app-key", "d27b37790dffabb01369e17d50050056b921a5bb");

                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    return response.Content.ToString();
                }
                else
                {
                    return response.Content.ToString();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
