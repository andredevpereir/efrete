using IPC.Correios.Core.Entities;
using System.Collections.Generic;

namespace IPC.Correios.Core.Repositories.Interfaces
{
    public interface ILogradouroRepository
    {
        Logradouro BuscarLogradouroPorCEP(int CEP);
        Logradouro BuscarLogradouroPorMunicipioNomeLogradouro(int codMunicipio, string nomeLogradouro);
        IEnumerable<Logradouro> ListarLogradouro(int codMunicipio);
    }
}
