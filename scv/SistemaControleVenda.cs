using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.Design;

//Essa é a classe Produto contendo os atributos do produto e seu construtor principal
class Produto
{
    public string Codigo { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public float Preco { get; set; }

    public Produto(string codigo, string nome, int quantidade, float preco)
    {
        Codigo = codigo;
        Nome = nome;
        Quantidade = quantidade;
        Preco = preco;
    }
}

//Essa é a classe Venda contendo os atributos da venda(incluindo o produto) e seu construtor principal
class Venda
{
    public Produto Produto { get; set; }
    public int QuantidadeVendida { get; set; }
    public float ValorTotal { get { return QuantidadeVendida * Produto.Preco; } }

    public Venda(Produto produto, int quantidadeVendida)
    {
        Produto = produto;
        QuantidadeVendida = quantidadeVendida;
    }
}

//Essa é a classe SistemaLoja contendo os métodos que o sistema utilizará(Cdastro de produto, registro de venda e geração de relatórios)
class SistemaLoja
{
    private static List<Produto> produtos = new List<Produto>();
    private static List<Venda> vendas = new List<Venda>();

    //No método de cadastro de produto eu solicito os dados do produto ao usuário,
    //incluo o produto, dou uma mensagem de cadastro e volto pro menu principal
    public static void CadastrarProduto()
    {
        Console.Clear();

        Console.Write("Digite o código do produto: ");
        string codigoProduto = Console.ReadLine();
        Console.Write("Digite o nome do produto: ");
        string nomeProduto = Console.ReadLine();
        Console.Write("Digite a quantidade em estoque: ");
        int quantidadeEstoque = int.Parse(Console.ReadLine());
        Console.Write("Digite o preço: ");
        float precoProduto = float.Parse(Console.ReadLine());

        produtos.Add(new Produto(codigoProduto, nomeProduto, quantidadeEstoque, precoProduto));

        Console.Clear();
        Console.WriteLine($"Produto {nomeProduto} cadastrado com sucesso.");

        Thread.Sleep(3000);
        Program.Menu();
    }

    //No método de registro de venda eu solicito os dados da venda ao usuário,
    //faço uma busca para verificar se o produto está cadsatrado
    //se o resultado da busca for nulo, ou seja, o produto não existir no cadastro
    //eu du uma mensagem "Produto não encontrado".
    //Também verifico a quantidade da venda, se a quantidade for menor que o estoque
    //dou uma mensagem "Estoque insuficiente".
    //Se os dados digitados não entrarem nos if's ao diminuo a quantidade da venda encima do estoque
    //depois adicino a venda.
    public static void RegistrarVenda()
    {
        Console.Clear();

        Console.Write("Digite o código do produto: ");
        string codigoProdutoVenda = Console.ReadLine();
        Console.Write("Digite a quantidade vendida: ");
        int quantidadeVendida = int.Parse(Console.ReadLine());

        Produto produto = produtos.Find(p => p.Codigo == codigoProdutoVenda);
        if (produto == null)
        {
            Console.Clear();
            Console.WriteLine("Produto não encontrado!");
            Thread.Sleep(3000);
            Program.Menu();
            return;
        }

        if (produto.Quantidade < quantidadeVendida)
        {
            Console.Clear();
            Console.WriteLine("Estoque insuficiente!");
            Thread.Sleep(3000);
            Program.Menu();
            return;
        }

        produto.Quantidade -= quantidadeVendida;
        vendas.Add(new Venda(produto, quantidadeVendida));

        Console.Clear();
        Console.WriteLine("Venda registrada com sucesso!");

        Thread.Sleep(3000);
        Program.Menu();
    }

    //No método de geração de relatório de vendas o sistema pede para o usuário digitar o caminho onde deseja salvar o arquivo
    //
    public static void GerarRelatorioVendas()
    {
        Console.Clear();

        Console.Write("Digite o diretório onde será salvo o arquivo de venda (Ex: D:\\Caminho\\Venda.csv): ");
        string caminhoArquivo = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(caminhoArquivo))
        {
            sw.WriteLine("Código | Nome | Quantidade Vendida | Valor Total");
            foreach (Venda venda in vendas)
            {
                sw.WriteLine($"{venda.Produto.Codigo}  |  {venda.Produto.Nome}  |  {venda.QuantidadeVendida}  |  R${venda.ValorTotal}");
            }
        }

        Console.Clear();
        Console.WriteLine($"Relatório de vendas gerado em: {caminhoArquivo}");

        Thread.Sleep(3000);
        Program.Menu();
    }

    public static void GerarRelatorioEstoque()
    {
        Console.Clear();

        Console.Write("Digite o diretório onde será salvo o arquivo de estoque (Ex: D:\\Caminho\\Estoque.txt): ");
        string caminhoArquivoEstoque = Console.ReadLine();

        using (StreamWriter sw = new StreamWriter(caminhoArquivoEstoque))
        {
            sw.WriteLine("Código | Nome | Quantidade em Estoque");
            foreach (Produto produto in produtos)
            {
                sw.WriteLine($"{ produto.Codigo }  |  { produto.Nome }  |  { produto.Quantidade }");
            }
        }

        Console.Clear();
        Console.WriteLine($"Relatório de estoque gerado em: {caminhoArquivoEstoque}");

        Thread.Sleep(3000);
        Program.Menu();
    }
}