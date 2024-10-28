namespace ecommerce_orientado_a_objetos
{
    internal class Program
    {
  
            private static List<Categoria> categorias = new List<Categoria>();
            private static List<Fornecedor> fornecedores = new List<Fornecedor>();
            private static List<Produto> produtos = new List<Produto>();

            static void Main(string[] args)
            {
                PopularBancoDados();
                int opcao;

                do
                {
                    Console.WriteLine("BEM VINDO AO SISTEMA DE ECOMMERCE");
                    Console.WriteLine(new string('=', 50));
                    Console.WriteLine("(1) - Adicionar Categoria");
                    Console.WriteLine("(2) - Adicionar Fornecedor");
                    Console.WriteLine("(3) - Adicionar Produto");
                    Console.WriteLine("(4) - Listar Categorias");
                    Console.WriteLine("(5) - Listar Fornecedores");
                    Console.WriteLine("(6) - Listar Produtos");
                    Console.WriteLine("(0) - Sair");
                    Console.Write("Digite sua opção: ");

                    if (!int.TryParse(Console.ReadLine(), out opcao))
                    {
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        continue;
                    }

                    switch (opcao)
                    {
                        case 1:
                            AdicionarCategoria();
                            break;

                        case 2:
                            AdicionarFornecedor();
                            break;

                        case 3:
                            AdicionarProduto();
                            break;

                        case 4:
                            ListarCategorias();
                            break;

                        case 5:
                            ListarFornecedores();
                            break;

                        case 6:
                            ListarProdutos();
                            break;

                        case 0:
                            Console.WriteLine("Saindo do sistema...");
                            break;

                        default:
                            Console.WriteLine("Opção inválida! Tente novamente.");
                            break;
                    }

                } while (opcao != 0);

                static void AdicionarCategoria()
                {
                    Console.Write("Digite o nome da nova categoria: ");
                    string nome = Console.ReadLine();
                    categorias.Add(new Categoria(nome));
                    Console.WriteLine("Categoria cadastrada com sucesso!");
                }

                static void AdicionarFornecedor()
                {
                    Console.Write("Digite o nome do fornecedor: ");
                    string nome = Console.ReadLine();
                    fornecedores.Add(new Fornecedor(nome));
                    Console.WriteLine("Fornecedor cadastrado com sucesso!");
                }

                static void AdicionarProduto()
                {
                    ListarCategorias();
                    Console.Write("Escolha uma categoria pelo número: ");
                    if (!int.TryParse(Console.ReadLine(), out int categoriaEscolhida) || !ValidarIndice(categoriaEscolhida - 1, categorias.Count))
                    {
                        Console.WriteLine("Categoria inválida!");
                        return;
                    }

                    ListarFornecedores();
                    Console.Write("Escolha um fornecedor pelo número: ");
                    if (!int.TryParse(Console.ReadLine(), out int fornecedorEscolhido) || !ValidarIndice(fornecedorEscolhido - 1, fornecedores.Count))
                    {
                        Console.WriteLine("Fornecedor inválido!");
                        return;
                    }

                    Console.Write("Digite o nome do produto: ");
                    string nomeProduto = Console.ReadLine();
                    produtos.Add(new Produto(nomeProduto, categorias[categoriaEscolhida - 1], fornecedores[fornecedorEscolhido - 1]));
                    Console.WriteLine("Produto cadastrado com sucesso!");
                }

                static void ListarCategorias()
                {
                    Console.WriteLine("CATEGORIAS CADASTRADAS:");
                    for (int i = 0; i < categorias.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {categorias[i].Nome}");
                    }
                }

                static void ListarFornecedores()
                {
                    Console.WriteLine("FORNECEDORES CADASTRADOS:");
                    for (int i = 0; i < fornecedores.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {fornecedores[i].Nome}");
                    }
                }

                static void ListarProdutos()
                {
                    Console.WriteLine("PRODUTOS CADASTRADOS:");
                    foreach (var produto in produtos)
                    {
                        Console.WriteLine($"Produto: {produto.Nome}, Categoria: {produto.Categoria.Nome}, Fornecedor: {produto.Fornecedor.Nome}");
                    }
                }

                static bool ValidarIndice(int indice, int limite)
                {
                    return indice >= 0 && indice < limite;
                }

                static void PopularBancoDados()
                {
                    string[] categoriasLote = { "Smartphones", "Acessórios", "Carregadores", "Capinhas", "Fones de ouvido" };
                    string[] fornecedoresLote = { "Samsung", "Apple", "Xiaomi", "Motorola", "LG" };
                    string[] produtosLote = { "Galaxy S21", "iPhone 13", "Redmi Note 10", "Moto G100", "LG Velvet" };

                    // Cadastrar categorias em lote
                    foreach (var nome in categoriasLote)
                    {
                        if (categorias.Count < 10)
                        {
                            categorias.Add(new Categoria(nome));
                        }
                    }

                    // Cadastrar fornecedores em lote
                    foreach (var nome in fornecedoresLote)
                    {
                        if (fornecedores.Count < 10)
                        {
                            fornecedores.Add(new Fornecedor(nome));
                        }
                    }

                    // Cadastrar produtos em lote com suas respectivas categorias e fornecedores
                    for (int i = 0; i < produtosLote.Length; i++)
                    {
                        if (produtos.Count < 10)
                        {
                            produtos.Add(new Produto(produtosLote[i], categorias[i], fornecedores[i]));
                        }
                    }

                    Console.WriteLine("Banco de dados inicializado com sucesso!");
                }
            }
        
    }
}

