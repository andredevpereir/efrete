using IPC.Correios.Core.Entities;
using IPC.Correios.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Correios.Core.Repositories.Implementations
{
    public class LogradouroRepository : ILogradouroRepository
    {
        private string[] dados;
        private string nomeArquivo = "LOG_LOGRADOURO_SC.TXT";
        public LogradouroRepository()
        {
            var caminhaoPadrao = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            string path = Path.Combine(caminhaoPadrao, @"App_Data\Correios\" + nomeArquivo);
            this.dados = File.ReadAllLines(path);
        }

        private void ExtrairDados()
        {
            foreach (string dado in dados)
            {

            }
        }

        public Logradouro BuscarLogradouroPorCEP(int CEP)
        {
            var dados = this.dados;

            return null;
        }

        public Logradouro BuscarLogradouroPorMunicipioNomeLogradouro(int codMunicipio, string nomeLogradouro)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Logradouro> ListarLogradouro(int codMunicipio)
        {
            throw new NotImplementedException();
        }
    }
}
