using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryExercise_2.Entities
{
    internal class Produto
    {
        public string Nome { get; set; }

        public double Preco { get; set; }

        public int Quantidade { get; set; }

        public Produto(string nome, double preco, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        public Produto()
        {
        }

        public double Totalizar()
        {
            return Preco * Quantidade;
        }

    }
}
