using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Jogadores");
            Console.WriteLine("\n Nome                 Posição     Clube             Golos marcados   Golos sofridos");
            StreamReader sr = new StreamReader("dados.txt");

            int s = 0;
            string linha = sr.ReadLine();

            while (linha != "" & linha != null)
            {
                string[] aux = linha.Split('|');

                Console.WriteLine("\n" + aux[0] + "   " + aux[1] + "      " + aux[2] + "      " + aux[3] + "      " + aux[4]);
            }
        }
    }
}
