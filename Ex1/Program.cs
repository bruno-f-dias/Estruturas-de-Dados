using System;

namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            string op;
            do
            {
                string num1, num2;
                Console.WriteLine("Selecione uma operação:");
                Console.WriteLine("\n+. Adição;\n-. Subtração\n*. Multiplicação;\n/. Divisão.\ns. Sair");
                op = Console.ReadLine();
                if (op == "+")
                {
                    Console.WriteLine("Escreva o primeiro número: ");
                    num1 = Console.ReadLine();
                    Console.WriteLine("Escreva o segundo número: ");
                    num2 = Console.ReadLine();
                    Console.WriteLine("Resultado: " + (Int32.Parse(num1) + Int32.Parse(num2)));
                }
                else if (op == "-")
                {
                    Console.WriteLine("Escreva o primeiro número: ");
                    num1 = Console.ReadLine();
                    Console.WriteLine("Escreva o segundo número: ");
                    num2 = Console.ReadLine();
                    Console.WriteLine("Resultado: " + (Int32.Parse(num1) - Int32.Parse(num2)));
                }
                else if (op == "*")
                {
                    Console.WriteLine("Escreva o primeiro número: ");
                    num1 = Console.ReadLine();
                    Console.WriteLine("Escreva o segundo número: ");
                    num2 = Console.ReadLine();
                    Console.WriteLine("Resultado: " + (Int32.Parse(num1) * Int32.Parse(num2)));
                }
                else if (op == "/")
                {
                    Console.WriteLine("Escreva o primeiro número: ");
                    num1 = Console.ReadLine();
                    Console.WriteLine("Escreva o segundo número: ");
                    num2 = Console.ReadLine();
                    if (num2 != "0")
                    {
                        Console.WriteLine("Resultado: " + (Int32.Parse(num1) / Int32.Parse(num2)));
                    }
                    else
                    {
                        Console.WriteLine("Não é possível dividir por zero");
                    }
                }
            } while (op=="s");
        }
    }
}
