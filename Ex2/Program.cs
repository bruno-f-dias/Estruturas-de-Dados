using System;
using System.Linq;
using System.Collections.Generic;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num, est;
            List<int> numeros = new List<int>();
            List<int> estrelas = new List<int>();
            Random r = new Random();
            for (int i = 0; i <= 5; i++)
            {
                num = r.Next(1, 51);
                if (numeros.Contains(num) == false)
                {
                    numeros.Add(num);
                }
            }
            for (int j = 0; j <= 1; j++)
            {
                est = r.Next(1, 13);
                if (estrelas.Contains(est) == false)
                {
                    estrelas.Add(est);
                }   
            }

            numeros.Sort();
            estrelas.Sort();
            Console.WriteLine("Resultados do Euromilhões!\nOs números vencedores são:");
            Console.WriteLine(string.Join(", ", numeros));
            Console.WriteLine("\nAs estrelas vencedoras são:");
            Console.WriteLine(string.Join(", ", estrelas));

        }
    }
}
