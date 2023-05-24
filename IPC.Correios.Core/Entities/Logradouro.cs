using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Correios.Core.Entities
{
    public class Logradouro
    {
        public int CodLogradouro { get; private set; }
        public int CodMunicipio { get; private set; }
        public string NomeLogradouro { get; private set; }
        public int CEP { get; private set; }

        public IEnumerable<Municipio> Municipios { get; private set; } = Enumerable.Empty<Municipio>();

        public Logradouro(
            int codLogradouro,
            int codMunicipio,
            string nomeLogradouro,
            int CEP,
            IEnumerable<Municipio> municipios)
        {
            this.CodLogradouro = codLogradouro;
            this.CodMunicipio = codMunicipio;
            this.NomeLogradouro = nomeLogradouro;
            this.CEP = CEP;
            this.Municipios = municipios;
        }
    }
}
