using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Test.FizzBuzz
{
    public class FizzBuzzUnitTest
    {
        private Dictionary<int, string[]> entradaSaida = new Dictionary<int, string[]>
        {
            { 3, new[] { "1", "2", "Fizz" } },
            { 5, new[] { "1","2","Fizz","4","Buzz" } },
            { 15, new[] {"1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz" } }
        };

        [TestCase(3)]
        [TestCase(5)]
        [TestCase(15)]
        public void MetodoTeste(int numeroTeste)
        {
            //Arrange

            //Act
            var resultado = FizzBuzz(numeroTeste).ToArray();

            //Assert
            var saidaEsperada = entradaSaida[numeroTeste];

            Assert.AreEqual(saidaEsperada.Length, resultado.Count());

            for (int i = 0; i < saidaEsperada.Length; i++)
            {
                Assert.AreEqual(saidaEsperada[i], resultado[i]);
            }
        }

        /*
         * Dado um n�mero inteiro, retorne um array de string onde:

          resposta[i] == "FizzBuzz" se i for divis�vel por 3 e por 5
          resposta[i] == "Fizz" se i for divis�vel por 3
          resposta[i] == "Buzz" se i for divis�vel por 5
          resposta[i] == valor de i como string, caso nenhuma regra anterior tenha sido atendida

          Exemplo 1:
            Input: n = 3
            Output: ["1","2","Fizz"]
          
          Exemplo 2:
            Input: n = 5
            Output: ["1","2","Fizz","4","Buzz"]

          Exemplo 3:
            Input: n = 15
            Output: ["1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz"]
         */

        public IEnumerable<string> FizzBuzz(int v)
        {
            if (v <= 0) return new[] { v.ToString() };

            string[] a = { };

            Array.Resize(ref a, v);

            for (int i = 1; i <= v; i++)
            {
                int pos = i - 1;

                bool porTres = i % 3 == 0;
                bool porCinco = i % 5 == 0;

                if (porTres && porCinco) { a[pos] = "FizzBuzz"; continue; }
                if (porTres) { a[pos] = "Fizz"; continue; }
                if (porCinco) { a[pos] = "Buzz"; continue; }

                a[pos] = i.ToString();
            }

            return a;
        }


    }
}
