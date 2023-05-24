using IPC.Correios.Core.Entities;
using System.Collections.Generic;

namespace IPC.Correios.Core.Repositories.Interfaces
{
    public interface IMunicipioRepository
    {
        Municipio BuscaMunicipio(int codMunicipio);
        Municipio BuscaMunicipio(string nomeMunicipio, string UF);
        IEnumerable<Municipio> ListaMunicipios(string UF);
    }
}
