using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;

//ESTE PROGRAMA CONTÉM MUTOS COMENTÁRIO PORQUE A ATIVIDADE ERA PRA TER SIDO FEITA EM PYTON
//ENTRETANTO O PROFESSOR SANDRO PERMITIU FAZER USANDO C# E ORIENTOU QUE TIVESSE UMA BOA DOCUMENTAÇÃO
//POR ISSO OS MUITOS COMENTÁRIOS NO CÓDIGO

class Program
{
    static void Main(string[] args)

    {
        //Aqui o sistema chama o método Menu para ajudar o usuário na escolha do que fazer dentro do sistema
        Menu();
    }

    //Esse é o conteúdo do método Menu
    public static void Menu()
    {
        //As opções vão ser exibidas na tela do console para o usuário interagir
        Console.Clear();
        Console.WriteLine("Sistema de Controle de Vendas");
        Console.WriteLine("-----------------------------");
        Console.WriteLine("1 - Cadastrar Produto");
        Console.WriteLine("2 - Registrar Venda");
        Console.WriteLine("3 - Relatorio de Vendas");
        Console.WriteLine("4 - Relatorio de Estoque");
        Console.WriteLine("0 - Sair");
        Console.WriteLine("-----------------------------");
        Console.Write("Resposta: ");

        int resposta = int.Parse(Console.ReadLine());

        //Aqui eu uso a estrutura condicional Switch Case para trabalhar a opção escolhida
        //pelo usuário e direcionar para a classe e método que corresmpondem a sua escolha
        switch (resposta)
        {
            case 1: SistemaLoja.CadastrarProduto(); break;
            case 2: SistemaLoja.RegistrarVenda(); ; break;
            case 3: SistemaLoja.GerarRelatorioVendas(); break;
            case 4: SistemaLoja.GerarRelatorioEstoque(); break;
            case 0:
                Console.Clear();
                Console.WriteLine("Aplicação Finalizada!");
                Environment.Exit(0); break;
            default: Console.WriteLine("Aplicação Finalizada!"); break;
        }
    }
}