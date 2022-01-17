using SdmBoletos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SdmBoletos.Repositorios
{
    public interface IBoletos
    {
        string BuscarBoletos(string Token, string Indicador, Dictionary<string, object>Parametros);
        string BuscarBoletosTeste(string Token, string Indicador, Dictionary<string, object> Parametros);
        string CriarBoletosTeste(string Token, object json);
        List<string> CriarBoletos(string Token, object json);
        string AlterarBoletosTeste(string Token, string Id, object sParametros);
        string AlterarBoletos(string Token, string Id,  object Parametros);
        string BaixarBoletos(string Token, string Id, object Parametros);
        string BuscarBoletoId(string Token, string Id);
        string BuscarBoletoIdTeste(string Token, string Id);
    
    }
}
