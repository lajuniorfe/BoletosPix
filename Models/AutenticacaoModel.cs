using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SdmBoletos.Models
{
    public class AutenticacaoModel
    {
        [JsonProperty("access_token")]
        public string TokenAcesso { get; set; }

        [JsonProperty("token_type")]
        public string TipoToken { get; set; }

        [JsonProperty("expires_in")]
        public int TempoExpirar { get; set; }
    }
}
