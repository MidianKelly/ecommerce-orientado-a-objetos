using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_orientado_a_objetos
{
    internal class Produto
    {
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public Produto(string nome, Categoria categoria, Fornecedor fornecedor)
        {
            Nome = nome;
            Categoria = categoria;
            Fornecedor = fornecedor;
        }
    }
}
