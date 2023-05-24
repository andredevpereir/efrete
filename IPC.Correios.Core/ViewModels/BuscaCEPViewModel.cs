using IPC.Correios.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Correios.Core.ViewModels
{
    public class BuscaCEPViewModel
    {
        public int CodLogradouro { get; set; }
        public string NomeLogradouro { get; set; }
        public string NomeMunicipio { get; set; }
        public int CEP { get; set; }

        public BuscaCEPViewModel(
            int codLogradouro,
            string nomeLogradouro,
            string nomeMunicipio,
            int CEP)
        {
            this.CodLogradouro = codLogradouro;
            this.NomeLogradouro = nomeLogradouro;
            this.NomeMunicipio = nomeMunicipio;
            this.CEP = CEP;
        }
    }
}
