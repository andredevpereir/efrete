using IPC.Correios.Core.Entities;
using IPC.Correios.Core.ValueObjects;
using IPC.Correios.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Correios.Core.Services.Interfaces
{
    public interface IEnderecoService
    {
        IEnumerable<Municipio> ListarMunicipios(string uf);
        IEnumerable<Logradouro> ListarLogradouros(int codMunicipio);
        Dictionary<string, string> ListarEstados();
        Logradouro BuscarLogradouro(int CEP);
        Logradouro BuscarLogradouro(string nomeLogradouro);
        UF BuscarEstadoPorSigla(string sigla);
        UF BuscarEstadoPorNomeEstado(string nomeEstado);
        BuscarEnderecoViewModel BuscarEndereco(int CEP);
        BuscaCEPViewModel BuscarCEP(string uf, string nomeMunicipio, string nomeLogradouro);
    }
}
