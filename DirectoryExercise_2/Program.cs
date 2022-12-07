using DirectoryExercise_2.Entities;
using System.Collections.Generic;
using System.Globalization;

namespace DirectoryExercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Informe o nome do arquivo a ser buscado: ");
            string nomeArq = Console.ReadLine();

            try
            {

                var arquivos = from arquivo in Directory.EnumerateFiles(@"c:\temp", "*.*")

                               where arquivo.ToLower().Contains(nomeArq)
                               select arquivo;

                Console.WriteLine();

                foreach (var item in arquivos)
                {
                    Console.WriteLine("{0}", item);
                }
                Console.WriteLine();
                Console.WriteLine("{0} Arquivos encontrados", arquivos.Count<string>().ToString());
                Console.WriteLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            Directory.CreateDirectory(@"c:\temp\csv");

            string[] prodV = new string[8];
            int i = 0;
            Console.WriteLine();
            Console.WriteLine("Digite os valores: Nome, Preço, Quantidade");

            while (i < 8)
            {
                prodV[i] = Console.ReadLine();
                i++;
            }
            Console.WriteLine();
            Console.WriteLine();
            
            using (StreamWriter fileWriter = File.AppendText(@"c:\temp\csv\ItensVendidos.csv"))
            {
                foreach (var item in prodV)
                {
                    string[] campos = item.Split(',');
                    string nome = campos[0];
                    double preco = double.Parse(campos[1], CultureInfo.InvariantCulture);
                    int quantidade = int.Parse(campos[2]);

                    Produto prod = new Produto(nome, preco, quantidade);

                    fileWriter.WriteLine(prod.Nome + ", " + prod.Preco + ", " + prod.Quantidade);

                }
            }

            try
            {
                var arquivos = from arquivo in Directory.EnumerateFiles(@"c:\temp\csv", "*.csv")
                               where arquivo.ToLower().Contains("ItensVendidos")
                               select arquivo;

                Console.WriteLine();
                Console.WriteLine("Arquivo contido em ItensVendidos: ");
                StreamReader leitor = new StreamReader(@"c:\temp\csv\ItensVendidos.csv");
                string linha = leitor.ReadLine();
                while (linha != null)
                {
                    Console.WriteLine(linha);
                    linha = leitor.ReadLine();  
                }
                leitor.Close();
                Console.WriteLine();

                Console.WriteLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            Directory.CreateDirectory(@"c:\temp\destino");

            using (StreamWriter escritorArquivo = File.AppendText(@"c:\temp\destino\resumo.csv"))
            {
                foreach (var item in prodV)
                {
                    string[] campos = item.Split(',');
                    string nome = campos[0];
                    double preco = double.Parse(campos[1], CultureInfo.InvariantCulture);
                    int quantidade = int.Parse(campos[2]);

                    Produto prod = new Produto(nome, preco, quantidade);

                    escritorArquivo.WriteLine(prod.Nome + ", " + prod.Totalizar().ToString("f2", CultureInfo.InvariantCulture));

                }
            }



        }
    }
}
