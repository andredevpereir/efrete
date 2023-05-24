using IPC.Correios.Core.Entities;
using IPC.Correios.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Correios.Core.Repositories.Implementations
{
    public class MunicipioRepository : IMunicipioRepository
    {
        private string[] dados;
        private string nomeArquivo = "LOG_LOCALIDADE.TXT";
        public MunicipioRepository()
        {
            var caminhaoPadrao = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            string path = Path.Combine(caminhaoPadrao, @"App_Data\Correios\" + nomeArquivo);
            this.dados = File.ReadAllLines(path);
        }

        public Municipio BuscaMunicipio(int codMunicipio)
        {
            throw new NotImplementedException();
        }

        public Municipio BuscaMunicipio(string nomeMunicipio, string UF)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Municipio> ListaMunicipios(string UF)
        {
            throw new NotImplementedException();
        }
    }
}
