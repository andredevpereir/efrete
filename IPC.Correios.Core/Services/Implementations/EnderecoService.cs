using IPC.Correios.Core.Entities;
using IPC.Correios.Core.Repositories.Interfaces;
using IPC.Correios.Core.Services.Interfaces;
using IPC.Correios.Core.ValueObjects;
using IPC.Correios.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Correios.Core.Services.Implementations
{
    public class EnderecoService : IEnderecoService
    {
        protected readonly IMunicipioRepository _municipioRepository;
        protected readonly ILogradouroRepository _logradouroRepository;

        public EnderecoService(
            IMunicipioRepository municipioRepository,
            ILogradouroRepository logradouroRepository) 
        {
            _municipioRepository = municipioRepository;
            _logradouroRepository = logradouroRepository;
        }

        public BuscaCEPViewModel BuscarCEP(string uf, string nomeMunicipio, string nomeLogradouro)
        {
            Municipio municipio = this._municipioRepository.BuscaMunicipio(nomeMunicipio, uf);
            Logradouro logradouro = this._logradouroRepository.BuscarLogradouroPorMunicipioNomeLogradouro(municipio.CodMunicipio, nomeLogradouro);

            return new BuscaCEPViewModel(
                logradouro.CodLogradouro,
                logradouro.NomeLogradouro,
                municipio.NomeMunicipio,
                logradouro.CEP);
        }

        public BuscarEnderecoViewModel BuscarEndereco(int CEP)
        {
            Logradouro logradouro = this._logradouroRepository.BuscarLogradouroPorCEP(CEP);
            Municipio municipio = this._municipioRepository.BuscaMunicipio(logradouro.CodMunicipio);

            return new BuscarEnderecoViewModel(
                logradouro.NomeLogradouro,
                municipio.NomeMunicipio,
                municipio.UF.Sigla,
                municipio.NomeMunicipio,
                logradouro.CEP);
        }

        public UF BuscarEstadoPorNomeEstado(string nomeEstado)
        {
            return new UF(UF.ListaSiglaNome.Single(x => x.Value.ToUpper() == nomeEstado.ToUpper()).Key);
        }

        public UF BuscarEstadoPorSigla(string sigla)
        {
            return new UF(sigla);
        }

        public Logradouro BuscarLogradouro(string nomeLogradouro)
        {
            throw new NotImplementedException();
        }

        public Logradouro BuscarLogradouro(int CEP)
        {
            return this._logradouroRepository.BuscarLogradouroPorCEP(CEP);
        }

        public Dictionary<string, string> ListarEstados()
        {
            return UF.ListaSiglaNome;
        }

        public IEnumerable<Logradouro> ListarLogradouros(int codMunicipio)
        {
            return this._logradouroRepository.ListarLogradouro(codMunicipio);
        }

        public IEnumerable<Municipio> ListarMunicipios(string uf)
        {
            return this._municipioRepository.ListaMunicipios(uf);
        }
    }
}
