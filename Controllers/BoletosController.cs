using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SdmBoletos.Models;
using SdmBoletos.Repositorios;
using System;
using System.Collections.Generic;

namespace SdmBoletos.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Route("api/[Controller]")]
    public class BoletosController : Controller
    {
        private readonly IGerarToken _gerarToken;
        private readonly IBoletos _Boletos;

        public BoletosController(IGerarToken gerarToken, IBoletos buscarBoletos)
        {
            _gerarToken = gerarToken;
            _Boletos = buscarBoletos;
        }


        [HttpPost("buscarboletos/{indicador}/{teste}")]
        public IActionResult BuscarBoletos(string indicador, string teste, [FromBody] Dictionary<string, object> ParametrosRecebido)
        {
            try
            {

                if (teste == "s")
                {
                    var tokenTeste = _gerarToken.GerarTokenTeste();
                    var jsonTeste = JsonConvert.DeserializeObject<AutenticacaoModel>(tokenTeste);
                    var boletosTeste = _Boletos.BuscarBoletosTeste(jsonTeste.TokenAcesso, indicador.ToUpper(), ParametrosRecebido);

                    return new ObjectResult(boletosTeste);
                }
                else
                {
                    var token = _gerarToken.GerarToken();
                    var json = JsonConvert.DeserializeObject<AutenticacaoModel>(token);
                    var boletos = _Boletos.BuscarBoletos(json.TokenAcesso, indicador, ParametrosRecebido);

                    if (boletos.Contains("erros"))
                    {
                        return BadRequest(boletos);
                    }
                    else
                    {
                        return new ObjectResult(boletos);
                    }
                        
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("criarboletos/{teste}")]
        public IActionResult CriarBoletos(string teste, [FromBody] object Parametros)
        {
            try
            {
                if (teste == "s")
                {
                    var tokenTeste = _gerarToken.GerarTokenTeste();
                    var jsonTeste = JsonConvert.DeserializeObject<AutenticacaoModel>(tokenTeste);
                    var boletosTeste = _Boletos.CriarBoletosTeste(jsonTeste.TokenAcesso, Parametros);

                    return new ObjectResult(boletosTeste);
                }
                else
                {
                    var token = _gerarToken.GerarToken();
                    var json = JsonConvert.DeserializeObject<AutenticacaoModel>(token);
                    var boletos = _Boletos.CriarBoletos(json.TokenAcesso, Parametros);

                    foreach(var i in boletos)
                    {
                        if(i.ToString().Contains("Created"))
                        {
                            return new ObjectResult(boletos[1]);
                           
                        }
                        else
                        {
                            if(i.ToString().Contains("InternalServerError"))
                            {
                                return BadRequest(boletos[1].ToString());
                            }
                            var erro = boletos[1];

                            if (erro.Contains("Titulo ja incluido anteriormen te."))
                            {
                                return NoContent();
                            }
                            else
                            {
                                return NotFound(boletos[1].ToString());
                            }
                        }
                    }

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("alterarboletos/{idboleto}/{teste}")]
        public IActionResult AlterarBoleto(string IdBoleto, string teste, [FromBody] object Parametros)
        {
            try
            {
                if (teste == "s")
                {
                    var tokenTeste = _gerarToken.GerarTokenTeste();
                    var jsonTokenTeste = JsonConvert.DeserializeObject<AutenticacaoModel>(tokenTeste);
                    var boletosTeste = _Boletos.AlterarBoletosTeste(jsonTokenTeste.TokenAcesso, IdBoleto, Parametros);

                    return new ObjectResult(boletosTeste);
                }
                else
                {
                    var token = _gerarToken.GerarToken();
                    var jsonToken = JsonConvert.DeserializeObject<AutenticacaoModel>(token);
                    var boletos = _Boletos.AlterarBoletos(jsonToken.TokenAcesso, IdBoleto, Parametros);

                    return new ObjectResult(boletos);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("BaixarBoleto/{idboleto}")]
        public IActionResult BaixarBoleto(string IdBoleto, [FromBody] object Parametros)
        {
            try
            {
                var token = _gerarToken.GerarToken();
                var jsonToken = JsonConvert.DeserializeObject<AutenticacaoModel>(token);
                var boletos = _Boletos.BaixarBoletos(jsonToken.TokenAcesso, IdBoleto, Parametros);
                if (boletos.Contains("errors"))
                {
                    return BadRequest(boletos);
                }

                return new ObjectResult(boletos);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("BoletosId/{idBoleto}/{teste}")]
        public IActionResult BuscarBoletosId(string idBoleto, string teste)
        {
            try
            {
                if(teste == "s")
                {
                    var tokenTeste = _gerarToken.GerarTokenTeste();
                    var jsonTeste = JsonConvert.DeserializeObject<AutenticacaoModel>(tokenTeste);
                    var infoBoletosTeste = _Boletos.BuscarBoletoIdTeste(tokenTeste, idBoleto);

                    return new ObjectResult(infoBoletosTeste);
                }
                else
                {
                    var token = _gerarToken.GerarToken();
                    var json = JsonConvert.DeserializeObject<AutenticacaoModel>(token);
                    var infoBoleto = _Boletos.BuscarBoletoId(json.TokenAcesso, idBoleto);
                    if (infoBoleto.Contains("errors"))
                    {
                        return BadRequest(infoBoleto);
                    }
                    else
                    {
                         return new ObjectResult(infoBoleto);

                    }
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
      
    }
}
