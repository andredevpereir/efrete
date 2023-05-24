using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Correios.Core.ViewModels
{
    public class BuscarEnderecoViewModel
    {
        public string NomeLogradouro { get; set; }
        public string NomeMunicipio { get; set; }
        public string UF { get; set; }
        public string NomeBairro { get; set; }
        public int CEP { get; set; }

        public BuscarEnderecoViewModel(
            string nomeLogradouro,
            string nomeMunicipio,
            string UF,
            string nomeBairro,
            int CEP)
        {
            this.NomeLogradouro = nomeLogradouro;
            this.NomeMunicipio = nomeMunicipio;
            this.UF = UF;
            this.NomeBairro = nomeBairro;
            this.CEP = CEP;
        }
    }
}
