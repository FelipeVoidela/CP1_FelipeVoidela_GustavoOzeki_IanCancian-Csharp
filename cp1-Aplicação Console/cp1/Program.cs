using System;

class Program
{
    static string[] produtos = { "X-Burguer", "Refrigerante", "Sorvete" };
    static double[] precos = { 25.00, 5.00, 7.50 };
    static int[] quantidades = new int[produtos.Length];
    static double total = 0.0;
    static int totalItens = 0;

    static void Main(string[] args)
    {
        int opcao;

        do
        {
            Console.WriteLine("Menu de Pedidos");
            Console.WriteLine("1.Listar produtos disponíveis");
            Console.WriteLine("2.Adicionar produto ao pedido");
            Console.WriteLine("3.Remover produto do pedido");
            Console.WriteLine("4.Visualizar pedido atual");
            Console.WriteLine("5.Finalizar pedido e sair");
            Console.WriteLine("Escolha uma opção: ");
            opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    ListarProdutos();
                    break;
                case 2:
                    AdicionarProduto();
                    break;
                case 3:
                    RemoverProduto();
                    break;
                case 4:
                    VisualizarPedido();
                    break;
                case 5:
                    FinalizarPedido();
                    break;
                default:
                    Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente...");
                    Console.ReadKey();
                    break;
            }

        } while (opcao != 5);
    }


    static void ListarProdutos()
    {
        Console.WriteLine("Produtos Disponíveis");
        for (int i = 0; i < produtos.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {produtos[i]} - R$ {precos[i]:F2}");
        }
        Console.WriteLine("Pressione qualquer tecla para voltar...");
        Console.ReadKey();
    }

    static void AdicionarProduto()
    {
        Console.WriteLine("Adicionar Produto ao Pedido");
        Console.WriteLine("Digite o número do produto que deseja adicionar: ");
        int indice = Convert.ToInt32(Console.ReadLine()) - 1;

        if (indice >= 0 && indice < produtos.Length)
        {
            Console.WriteLine($"Quantas unidades de {produtos[indice]} você deseja adicionar?");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            if (quantidade > 0)
            {
                quantidades[indice] += quantidade;
                totalItens += quantidade;
                total += precos[indice] * quantidade;
                Console.WriteLine($"{quantidade} unidades de {produtos[indice]} foram adicionadas ao seu pedido.");
            }
            else
            {
                Console.WriteLine("Quantidade inválida. Pressione qualquer tecla para tentar novamente...");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado. Pressione qualquer tecla para tentar novamente...");
        }

        Console.ReadKey();
    }

    static void RemoverProduto()
    {
        Console.WriteLine("Remover Produto do Pedido");
        Console.WriteLine("Digite o número do produto que deseja remover: ");
        int indice = Convert.ToInt32(Console.ReadLine()) - 1;

        if (indice >= 0 && indice < produtos.Length && quantidades[indice] > 0)
        {
            Console.WriteLine($"Quantas unidades de {produtos[indice]} você deseja remover?");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            if (quantidade > 0 && quantidades[indice] >= quantidade)
            {
                quantidades[indice] -= quantidade;
                totalItens -= quantidade;
                total -= precos[indice] * quantidade;
                Console.WriteLine($"{quantidade} unidades de {produtos[indice]} foram removidas do seu pedido.");
            }
            else
            {
                Console.WriteLine("Quantidade inválida ou maior do que a quantidade no pedido. Pressione qualquer tecla para tentar novamente...");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado ou não presente no pedido. Pressione qualquer tecla para tentar novamente...");
        }

        Console.ReadKey();
    }

    static void VisualizarPedido()
    {
        Console.WriteLine("Pedido Atual");
        for (int i = 0; i < produtos.Length; i++)
        {
            if (quantidades[i] > 0)
            {
                Console.WriteLine($"{produtos[i]} - {quantidades[i]} unidade(s) - R$ {precos[i] * quantidades[i]:F2}");
            }
        }
        Console.WriteLine($"Total de itens: {totalItens}");
        Console.WriteLine($"Valor bruto: R$ {total:F2}");
        Console.WriteLine("Pressione qualquer tecla para voltar...");
        Console.ReadKey();
    }

    static void FinalizarPedido()
    {
        double valorFinal = total;

        if (total > 100)
        {
            double desconto = total * 0.10;
            valorFinal = total - desconto;
            Console.WriteLine($"Desconto de 10% aplicado: R$ {desconto:F2}");
        }

        if (totalItens > 5)
        {
            Console.WriteLine("Você ganhou um brinde e o frete é grátis!");
        }

        Console.WriteLine($"Valor final a pagar: R$ {valorFinal:F2}");
        Console.WriteLine("Obrigado por fazer o pedido! Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}
