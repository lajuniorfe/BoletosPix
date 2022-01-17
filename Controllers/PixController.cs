using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SdmBoletos.Models;
using SdmBoletos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SdmBoletos.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Route("api/[Controller]")]
    public class PixController : Controller
    {
        private readonly IGerarToken _gerarToken;
        private readonly IPix _Pix;

        public PixController(IGerarToken gerarToken, IPix pix)
        {
            _gerarToken = gerarToken;
            _Pix = pix;
        }

        [HttpPost("cobranca/{identificacao}")]
        public IActionResult GerarCobrancaPix([FromBody] dynamic Cobranca, string Identificacao)
        {
            try
            {
                var token = _gerarToken.GerarTokenPix();

                var JsonToken = JsonConvert.DeserializeObject<AutenticacaoModel>(token);

                var retorno = _Pix.GerarCobrancaPix(Identificacao, JsonToken.TokenAcesso, Cobranca);
                return new ObjectResult(retorno);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet("consultar/{identificacao}")]
        public IActionResult ConsultarCobrancaPix(string Identificacao)
        {
            try
            {
                var token = _gerarToken.GerarTokenPix();
                var JsonToken = JsonConvert.DeserializeObject<AutenticacaoModel>(token);

                var retornoConsulta = _Pix.ConsultarCobrancaPix(Identificacao, JsonToken.TokenAcesso);
                return new ObjectResult(retornoConsulta);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("recebidos")]
        public IActionResult ConsultarPixRecebidos([FromBody] Dictionary<string, dynamic> Dados)
        {
            try
            {
                var token = _gerarToken.GerarTokenPix();

                var JsonToken = JsonConvert.DeserializeObject<AutenticacaoModel>(token);

                var retornoConsulta = _Pix.ConsultarPixRecebidos(Dados, JsonToken.TokenAcesso);
                if (retornoConsulta.Contains("erros"))
                {
                    return BadRequest(retornoConsulta);
                }
                else
                {
                    return new ObjectResult(retornoConsulta);
                }

              
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("recebidos/{e2eid}")]
        public IActionResult ConsultarPixIdentificacao(string E2eid)
        {
            try
            {
                var token = _gerarToken.GerarTokenPix();

                var JsonToken = JsonConvert.DeserializeObject<AutenticacaoModel>(token);



                var retorno = _Pix.ConsultarPixIdentificacao(E2eid, JsonToken.TokenAcesso);

                return new ObjectResult(retorno);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
