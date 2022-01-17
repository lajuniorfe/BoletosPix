using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SdmBoletos.Repositorios
{
    public interface IPix
    {
        string GerarCobrancaPix(string IdIdentificacao, string Token, dynamic Json);
        string ConsultarCobrancaPix(string Identificacao, string Token);

        string ConsultarPixRecebidos(Dictionary<string, object> Parametros, string Token);

        string ConsultarPixIdentificacao(string E2eid, string Token);
    }
}
