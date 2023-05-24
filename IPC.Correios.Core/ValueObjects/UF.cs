using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Correios.Core.ValueObjects
{
    public class UF
    {
        public string Nome { get; private set; }
        public string Sigla { get; private set; }

        public static Dictionary<string, string> ListaSiglaNome { get; private set; } = new Dictionary<string, string>()
        {
            { "AC", "Acre"},
            { "AL", "Alagoas"},
            { "AP", "Amapá"},
            { "AM", "Amazonas"},
            { "BA", "Bahia"},
            { "CE", "Ceará"},
            { "DF", "Destrito Federal"},
            { "ES", "Espirito Santo"},
            { "GO", "Goiás"},
            { "MA", "Maranhão"},
            { "MT", "Mato Grosso"},
            { "MS", "Mato Grosso do Sul"},
            { "MG", "Minas Gerais"},
            { "PA", "Pará"},
            { "PB", "Paraíba"},
            { "PR", "Paraná"},
            { "PE", "Pernambuco"},
            { "PI", "Piauí"},
            { "RJ", "Rio de Janeiro"},
            { "RN", "Rio Grande do Norte"},
            { "RS", "Rio Grande do Sul"},
            { "RO", "Rondônia"},
            { "RR", "Roraima"},
            { "SC", "Santa Catarina"},
            { "SP", "São Paulo"},
            { "SE", "Sergipe"},
            { "TO", "Tocantins"}
        };

        public UF(string sigla)
        {
            this.Nome = UF.ListaSiglaNome.Single(x => x.Key == sigla).Value;
            this.Sigla = sigla;
        }
    }
}