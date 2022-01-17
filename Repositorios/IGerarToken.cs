using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SdmBoletos.Repositorios
{
    public interface IGerarToken
    {
        string GerarToken();
        string GerarTokenTeste();
        string GerarTokenPix();
    }
}
