using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            string retry = "sim";
            List<Pessoa> conta = new List<Pessoa>();

            do
            {
                Pessoa c = new Pessoa();
                Console.WriteLine("Registar utilizador");
                Console.WriteLine("\nIntroduza o seu nome:");
                c.SetNome(Console.ReadLine());
                Console.WriteLine("\nIntroduza a sua data de nascimento:");
                c.SetData(Console.ReadLine());
                Console.WriteLine("\nIntroduza o seu e-mail:");
                c.SetMail(Console.ReadLine());
                Console.WriteLine("\nConfirma que é o " + c.GetNome() + ", nascido em " + c.GetData() + "e o seu e-mail é " + c.GetMail() + ".");
                conta.Add(c);
                Console.WriteLine("\nPretende registar mais alguém? Escreve 'sim' para registar mais alguém.");
                retry = Console.ReadLine();
            } while (retry.ToLower() == "sim");

            
            StreamWriter pw = new StreamWriter("dados.txt");
            foreach (Pessoa x in conta)
            {
                pw.WriteLine(x.GetNome()+"|"+x.GetData()+"|"+x.GetMail());
            }
            pw.Close();
        }
    }
    class Pessoa
    {
        protected string nome;
        protected string data_nasc;
        protected string mail;

        public Pessoa()
        {
            nome = "";
            data_nasc = "";
            mail = "";
        }
        public Pessoa(string nome, string data_nasc, string mail)
        {
            this.nome = nome;
            this.data_nasc = data_nasc;
            this.mail = mail;
        }

        public string GetNome()
        {
            return nome;
        }
        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public string GetData()
        {
            return data_nasc;
        }
        public void SetData(string data_nasc)
        {
            this.data_nasc = data_nasc;
        }

        public string GetMail()
        {
            return mail;
        }
        public void SetMail(string mail)
        {
            this.mail = mail;
        }
    }
}
