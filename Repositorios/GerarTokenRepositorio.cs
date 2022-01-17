using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SdmBoletos.Repositorios
{
    public class GerarTokenRepositorio : IGerarToken
    {
        public string GerarToken()
        {
            var Autorization = "Basic ZXlKcFpDSTZJbVl3TnpabVlXVXROekJtTXkwMFlqRXhMV0prWVdJdE5UZzJNakpoSWl3aVkyOWthV2R2VUhWaWJHbGpZV1J2Y2lJNk1Dd2lZMjlrYVdkdlUyOW1kSGRoY21VaU9qRTBPVGMxTENKelpYRjFaVzVqYVdGc1NXNXpkR0ZzWVdOaGJ5STZNWDA6ZXlKcFpDSTZJakV5TVRNMU9Ua3ROems0WVMwME5XRTJMVGhsWVdNdFpTSXNJbU52WkdsbmIxQjFZbXhwWTJGa2IzSWlPakFzSW1OdlpHbG5iMU52Wm5SM1lYSmxJam94TkRrM05Td2ljMlZ4ZFdWdVkybGhiRWx1YzNSaGJHRmpZVzhpT2pFc0luTmxjWFZsYm1OcFlXeERjbVZrWlc1amFXRnNJam94TENKaGJXSnBaVzUwWlNJNkluQnliMlIxWTJGdklpd2lhV0YwSWpveE5qSTBNemd4T1RVMU1qUTNmUQ==";

            var Grant_type = "client_credentials";
            var scope = "cobrancas.boletos-requisicao cobrancas.boletos-info";
            var url = $"https://oauth.bb.com.br/oauth/token";

            var client = new RestClient(url);
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", Autorization);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", Grant_type);
            request.AddParameter("scope", scope);

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

        public string GerarTokenTeste()
        {
            var Autorization = "Basic ZXlKcFpDSTZJaUlzSW1OdlpHbG5iMUIxWW14cFkyRmtiM0lpT2pBc0ltTnZaR2xuYjFOdlpuUjNZWEpsSWpveE56RXhNQ3dpYzJWeGRXVnVZMmxoYkVsdWMzUmhiR0ZqWVc4aU9qRjk6ZXlKcFpDSTZJamhoWm1RMVlXUXROMk5sWmkwME1tUTVMVGxrWXpBdE5ETTBaakUzTkdNeVpERmtNV1kwTW1VMllqUXRJaXdpWTI5a2FXZHZVSFZpYkdsallXUnZjaUk2TUN3aVkyOWthV2R2VTI5bWRIZGhjbVVpT2pFM01URXdMQ0p6WlhGMVpXNWphV0ZzU1c1emRHRnNZV05oYnlJNk1Td2ljMlZ4ZFdWdVkybGhiRU55WldSbGJtTnBZV3dpT2pFc0ltRnRZbWxsYm5SbElqb2lhRzl0YjJ4dloyRmpZVzhpTENKcFlYUWlPakUyTWpNMk9EazJPVE0yT1RWOQ==";
            var Grant_type = "client_credentials";
            var scope = "cobrancas.boletos-requisicao cobrancas.boletos-info";

            var url = $"https://oauth.hm.bb.com.br/oauth/token";

            var client = new RestClient(url);
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", Autorization);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", Grant_type);
            request.AddParameter("scope", scope);

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

        public string GerarTokenPix()
        {
            var Autorization = "Basic ZXlKcFpDSTZJbU13WTJZM0lpd2lZMjlrYVdkdlVIVmliR2xqWVdSdmNpSTZNQ3dpWTI5a2FXZHZVMjltZEhkaGNtVWlPakUyTWpnM0xDSnpaWEYxWlc1amFXRnNTVzV6ZEdGc1lXTmhieUk2TVgwOmV5SnBaQ0k2SWpFM01qUXhaR010TURRNU5DMDBNR1ZoTFRnNE9XWXRObVV6TWpreU56VXlaamd3TURrM09TSXNJbU52WkdsbmIxQjFZbXhwWTJGa2IzSWlPakFzSW1OdlpHbG5iMU52Wm5SM1lYSmxJam94TmpJNE55d2ljMlZ4ZFdWdVkybGhiRWx1YzNSaGJHRmpZVzhpT2pFc0luTmxjWFZsYm1OcFlXeERjbVZrWlc1amFXRnNJam94TENKaGJXSnBaVzUwWlNJNkluQnliMlIxWTJGdklpd2lhV0YwSWpveE5qSTJNemM1TURVeE5EUXlmUQ==";
            var Grant_type = "client_credentials";
            var scope = "pix.read pix.write cob.read cob.write";

            var url = $"https://oauth.bb.com.br/oauth/token";

            var client = new RestClient(url);
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", Autorization);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", Grant_type);
            request.AddParameter("scope", scope);

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
    }
}
