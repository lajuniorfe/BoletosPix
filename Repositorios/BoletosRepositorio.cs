using Newtonsoft.Json;
using RestSharp;
using SdmBoletos.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SdmBoletos.Repositorios
{
    public class BoletosRepositorio : IBoletos
    {
        public string BuscarBoletos(string Token, string Indicador, Dictionary<string, object> Paramentros)
        {

            List<string> Chave = new List<string>();
            List<string> Valor = new List<string>();

            ListagemBoletosModel listagemBoletos = new ListagemBoletosModel();

            var url = $"https://api.bb.com.br/cobrancas/v1/boletos";

            var client = new RestClient(url);

            var request = new RestRequest(Method.GET);

            request.AddParameter("indicadorSituacao", $"{Indicador}");
            request.AddParameter("agenciaBeneficiario", listagemBoletos.AgenciaBeneficiario);
            request.AddParameter("contaBeneficiario", listagemBoletos.ContaBeneficiario);
            request.AddParameter("gw-dev-app-key", "");
            request.AddHeader("Authorization", $"Bearer {Token}");


            foreach (var c in Paramentros.Keys)
            {
                Chave.Add(Convert.ToString(c));
            }

            foreach (var v in Paramentros.Values)
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
                return response.Content;
            }
        }

        public string BuscarBoletosTeste(string Token, string Indicador, Dictionary<string, object> Paramentros)
        {
            List<string> Chave = new List<string>();
            List<string> Valor = new List<string>();

            ListagemBoletosModel listagemBoletos = new ListagemBoletosModel();


            listagemBoletos.AgenciaBeneficiario = "69696";
            listagemBoletos.ContaBeneficiario = "969696";

            var url = $"https://api.hm.bb.com.br/cobrancas/v1/boletos";

            var client = new RestClient(url);

            var request = new RestRequest(Method.GET);

            request.AddParameter("indicadorSituacao", $"{Indicador}");
            request.AddParameter("agenciaBeneficiario", listagemBoletos.AgenciaBeneficiario);
            request.AddParameter("contaBeneficiario", listagemBoletos.ContaBeneficiario);
            request.AddParameter("gw-dev-app-key", "");
            request.AddHeader("Authorization", $"Bearer {Token}");


            foreach (var c in Paramentros.Keys)
            {
                Chave.Add(Convert.ToString(c));
            }

            foreach (var v in Paramentros.Values)
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


            return response.Content;
        }

        public string CriarBoletosTeste(string Token, object json)
        {

            var url = "https://api.hm.bb.com.br/cobrancas/v1/boletos?gw-dev-app-key=69696";
            var client = new RestClient(url);
            client.Timeout = -1;

            var objetoConvertido = JsonConvert.SerializeObject(json.ToString());

            var request = new RestRequest(Method.POST);
           // request.AddParameter("gw-dev-app-key", "");
            request.AddParameter("application/json", objetoConvertido, ParameterType.RequestBody);
            request.AddHeader("Authorization", $"Bearer {Token}");
            request.AddHeader("Contente-Type", "application/json");


            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return response.Content;
            }
            else
            {
                response = client.Execute(request);
                return response.Content;
            }
        }

        public List<string> CriarBoletos(string Token, object json)
        {

            List<string> Retorno = new List<string>();

            var url = "https://api.bb.com.br/cobrancas/v1/boletos?gw-dev-app-key=99969696";
            var client = new RestClient(url);
            client.Timeout = -1;


            var objetoConvertido = JsonConvert.SerializeObject(json.ToString());

            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json", objetoConvertido, ParameterType.RequestBody);
            request.AddHeader("Authorization", $"Bearer {Token}");
            request.AddHeader("Contente-Type", "application/json");

            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Retorno.Add(response.StatusCode.ToString());
                Retorno.Add(response.Content);
                return Retorno;
            }
            else
            {
                response = client.Execute(request);

                Retorno.Add(response.StatusCode.ToString());
                Retorno.Add(response.Content);

                return Retorno;
            }

        }

        public string AlterarBoletosTeste(string Token, string Id, object Parametros)
        {

            var url = $"https://api.hm.bb.com.br/cobrancas/v1/boletos/{Id}?gw-dev-app-key=6969";

            var client = new RestClient(url);
            client.Timeout = -1;

            var json = JsonConvert.SerializeObject(Parametros.ToString());

            var request = new RestRequest(Method.PATCH);

            request.AddHeader("Authorization", $"Bearer {Token}");
            request.AddHeader("Content_Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return response.Content;
            }
            else
            {
                response = client.Execute(request);
                return response.Content;
            }

        }

        public string AlterarBoletos(string Token, string Id, object Parametros)
        {
            var url = $"https://api.bb.com.br/cobrancas/v1/boletos/{Id}?gw-dev-app-key=969696";

            var client = new RestClient(url);
            client.Timeout = -1;

            var json = JsonConvert.SerializeObject(Parametros.ToString());

            var request = new RestRequest(Method.PATCH);

            request.AddHeader("Authorization", $"Bearer {Token}");
            request.AddHeader("Content_Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return response.Content;
            }
            else
            {
                response = client.Execute(request);
                return response.Content;
            }
        }

        public string BaixarBoletos(string Token, string Id, object Parametros)
        {
            var url = $"https://api.bb.com.br/cobrancas/v1/boletos/{Id}/baixar?gw-dev-app-key=96996";

            var client = new RestClient(url);
            client.Timeout = -1;

            var json = JsonConvert.SerializeObject(Parametros.ToString());

            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            request.AddHeader("Authorization", $"Bearer {Token}");
            request.AddHeader("Content-Type", "application/json");
          
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return response.Content;
            }
            else
            {
                response = client.Execute(request);
                return response.Content;
            }
        }

        public string BuscarBoletoId(string Token, string Id)
        {

            var url = $"https://api.bb.com.br/cobrancas/v1/boletos/{Id}";

            var client = new RestClient(url);

            var request = new RestRequest(Method.GET);
            request.AddParameter("gw-dev-app-key", "969696");
            request.AddParameter("numeroConvenio", 969696);

            request.AddHeader("Authorization", $"Bearer {Token}");
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

        public string BuscarBoletoIdTeste(string Token, string Id)
        {


            ListagemBoletosModel listagemBoletos = new ListagemBoletosModel();

            listagemBoletos.AgenciaBeneficiario = "96969696";
            listagemBoletos.ContaBeneficiario = "69699696";

            var url = $"https://api.hm.bb.com.br/cobrancas/v1/boletos/{Id}";

            var client = new RestClient(url);

            var request = new RestRequest(Method.GET);

            request.AddParameter("indicadorSituacao", $"{Id}");
            request.AddParameter("gw-dev-app-key", "696969");
            request.AddHeader("Authorization", $"Bearer {Token}");

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

     
    }
}
