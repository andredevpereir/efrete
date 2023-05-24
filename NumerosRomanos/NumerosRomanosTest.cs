using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Test.NumerosRomanos
{
    public class NumerosRomanosTest
    {
        [TestCase("I", 1)]
        [TestCase("V", 5)]
        [TestCase("X", 10)]
        [TestCase("L", 50)]
        [TestCase("C", 100)]
        [TestCase("D", 500)]
        [TestCase("M", 1000)]
        [TestCase("III", 3)]
        [TestCase("LVIII", 58)]
        [TestCase("MCMXCIV", 1994)]
        public void Teste(string numeroRomano, int numeroInteiroEsperado)
        {
            //Arrange

            //Act
            var resultado = NumeroRomanoParaInteiro(numeroRomano);

            //Assert
            Assert.AreEqual(numeroInteiroEsperado, resultado);
        }

        /*
        Numeros romanos s�o repreentados por 7 diferentes simbolos: I, V, X, L, C, D e M.

        Simbolo     ValorValue
        I            1
        V            5
        X            10
        L            50
        C            100
        D            500
        M            1000

        Por exemplo, 2 � escrito II em romando, apenas dois 1's e somam-se. 12 � escrito XII, onde � simplesmente X(10) + II(2).
        O n�mero 27 � escrito XXVII, onde XX(20) + V(5) + II(2)
        
        Numeros romanos s�o geralmente escritos do mais alto para o mais baixo da esquerda para a direita
        Por�m o n�mero 4 n�o � IIII, e sim IV. Desta maneira, o I(1) � menor que V(5), o que gera 5-1, que � 4

        O mesmo princ�pio se aplica ao n�mero 9, que � escrito IX
        
        H� seis intancias onde a subtra��o � usada:
            I pode ser colocado antes de um V (5) e X (10) para gerar 4 e 9. 
            X pode ser colocado antes de um L (50) e C (100) para gerar 40 e 90. 
            C pode ser colocado antes de um D (500) e M (1000) para gerar 400 e 900.
            
        Visto isto, crie um m�todo que converta um numero romano num inteiro

            Exemplo 1:
            Input: s = "III"
            Output: 3
            Explica��o: III = 3.

            Exemplo 2:
            Input: s = "LVIII"
            Output: 58
            Explica��o: L = 50, V= 5, III = 3.

            Exemplo 3:
            Input: s = "MCMXCIV"
            Output: 1994
            Explica��o: M = 1000, CM = 900, XC = 90 and IV = 4. 

        Restri��es:
            O tamanho do n�mero romano enviado 1 <= s.length <= 15
            s cont�m apenas os caracteres a seguir ('I', 'V', 'X', 'L', 'C', 'D', 'M').
            � garantido que somente ser�o enviados n�meros romanos no seguinte intervalo [1, 3999].
        */

        private Dictionary<char, int> dicNumerosRomanos = new Dictionary<char, int>
        {
            { 'I', 1},
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        private Dictionary<string, int> duplas = new Dictionary<string, int>
        {
            { "IV", 4},
            { "IX", 9 },
            { "XL", 40 },
            { "XC", 90 },
            { "CD", 400 },
            { "CM", 900 }
        };

        const int CARACTER_MAXIMO_PERMITIDO = 15;

        private int NumeroRomanoParaInteiro(string numeroRomano)
        {
            if (string.IsNullOrEmpty(numeroRomano)) throw new ArgumentException("� necess�rio inserir ao menos caractere.");

            numeroRomano = numeroRomano.Trim().ToUpper();

            if (numeroRomano.Length == 1) return RetornaValorEmRomano(char.Parse(numeroRomano));

            return RetornaValorEmRomano(numeroRomano.ToCharArray());
        }

        private int RetornaValorEmRomano(char numeroRomanoChar)
        {
            if (!VerificaNumeroRomanoValido(numeroRomanoChar))
                throw new ArgumentException($"O caractere {numeroRomanoChar} n�o possui um correspodente romano.");

            return RomanoCorrespondente(numeroRomanoChar).Value;
        }

        private int RetornaValorEmRomano(char[] numerosRomanosChar)
        {
            if (numerosRomanosChar.Length > CARACTER_MAXIMO_PERMITIDO)
                throw new ArgumentException($"Os caracteres informados excedem o m�ximo permitido de {CARACTER_MAXIMO_PERMITIDO}.");

            VerificaNumerosRomanosValidos(numerosRomanosChar);
            VerificaSequencia(numerosRomanosChar);

            List<int> somar = new List<int>();

            KeyValuePair<char, int> anterior = new KeyValuePair<char, int>();

            foreach (char romanoChar in numerosRomanosChar)
            {
                var romanoCharAtual = RomanoCorrespondente(romanoChar);

                bool somenteSomar = anterior.Value == 0 || romanoCharAtual.Value <= anterior.Value;

                if (somenteSomar)
                {
                    somar.Add(romanoCharAtual.Value);
                    anterior = romanoCharAtual;

                    continue;
                }

                string dupla = anterior.Key.ToString() + romanoCharAtual.Key.ToString();

                VerificaDuplaNumeroRomanoValido(dupla);

                somar.Remove(somar.Last());

                somar.Add(DuplaRomanoCorrespondente(dupla).Value);

                anterior = romanoCharAtual;
            }

            return somar.Sum();
        }

        private void VerificaNumerosRomanosValidos(char[] romanos)
        {
            foreach (char romano in romanos)
            {
                if (!VerificaNumeroRomanoValido(romano))
                    throw new ArgumentException("Os caracteres informados n�o formam um n�mero romano v�lido.");
            }
        }

        private bool VerificaNumeroRomanoValido(char c)
        {
            return dicNumerosRomanos.ContainsKey(c);
        }

        private void VerificaDuplaNumeroRomanoValido(string c)
        {
            if (!duplas.ContainsKey(c))
                throw new ArgumentException($"A dupla {c} n�o possui um correspodente romano.");
        }

        private void VerificaSequencia(char[] algarismos)
        {
            char anterior = '\0';
            int repeticoes = 0;

            foreach (char algarismo in algarismos)
            {

                if (algarismo == anterior)
                {
                    if (repeticoes == 3)
                        throw new ArgumentException("N�o � permitido inserir mais de 3 caracteres iguais.");

                    anterior = algarismo;
                    repeticoes++;
                    continue;
                }

                anterior = algarismo;
                repeticoes = 1;
            }

        }

        private KeyValuePair<char, int> RomanoCorrespondente(char c)
        {
            KeyValuePair<char, int> nr = dicNumerosRomanos.Where(nr => nr.Key == c).FirstOrDefault();

            return nr;
        }

        private KeyValuePair<string, int> DuplaRomanoCorrespondente(string dupla)
        {
            KeyValuePair<string, int> nr = duplas.Where(d => d.Key == dupla).FirstOrDefault();

            return nr;
        }

    }

}