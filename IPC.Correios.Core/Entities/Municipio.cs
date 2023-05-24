using IPC.Correios.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPC.Correios.Core.Entities
{
    public class Municipio
    {
        public int CodMunicipio { get; private set; }
        public UF UF { get; private set; }
        public string NomeMunicipio { get; private set; }
        public int CodIBGE { get; private set; }

        public Municipio(
           int codMunicipio,
           UF UF,
           string nomeMunicipio,
           int codIBGE)
        {
            this.CodMunicipio = codMunicipio;
            this.UF = UF;
            this.NomeMunicipio = nomeMunicipio;
            this.CodIBGE = codIBGE;
        }
    }
}
