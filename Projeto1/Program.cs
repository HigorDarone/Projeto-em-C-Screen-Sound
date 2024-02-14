// Screen Sound

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";

//List<string> ListaDasBandas = new List<string> { "Froid" , "Matue"};

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Matue", new List<int> { 10, 8, 6 });
bandasRegistradas.Add("Froid", new List<int>());

//funcao para exibir o logo, usamos o @ antes para nao quebrar o formato 
void ExibirLogo() 
{


    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagemDeBoasVindas);
}

//exibinfo as opcao do menu, e usando o switch case para tratar a opcao escolhida
void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registar uma banda");
    Console.WriteLine("digite 2 Para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir nota da Banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opcao: ");
    String opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica) 
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarUmaBanda();
            break;
        case 4: ExibirAvaliacaoDaBanda();
            
            break;
        case -1:
            Console.WriteLine(" Voce escolheu a opcao sair do programa :( ");
            break;

            default: Console.WriteLine("Opcao Invalida ");
            break;
    }
}
//funcao para registrar a banda pelo console e adicionando a lista
void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de Bandas");
    Console.Write("Digite o nome da banda que deseja: ");
    string nomeDaBanda = Console.ReadLine()!;
    /*ListaDasBandas.Add(nomeDaBanda);*/
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();

}
//funcao onde mostramos a banda registrada com um for ou foreach na lista onde esta salva as bandas
void MostrarBandasRegistradas()
{  
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas");

   /* for(int i = 0; i < ListaDasBandas.Count; i++)
    {
        Console.WriteLine($"Banda: {ListaDasBandas[i]} ");
    }*/

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda} ");
    }

    Console.Write("\nDigite qualquer tecla para voltar para o Menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

// funcao apenas para o titulo ter o desing dos asteristicos em cima e embaixo deles, com o tanto de letras certas
  void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras,'*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmaBanda()
{
    //digite  qual banda deseja avaliar
    //se a banda existir no dicionarios >> atribuir nota
    // senao existir voltar ao menu principal
    
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine();
    if(bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"A nota {nota} foi registrada com sucesso para a banda {nomeDaBanda} ");
        Thread.Sleep(2500);
        Console.Clear() ;
        ExibirOpcoesDoMenu();
    }
    else
    { 
        Console.WriteLine($"\nA banda {nomeDaBanda} nao foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao Menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void ExibirAvaliacaoDaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Media Da banda");
    Console.Write("\nDigite o nome da banda que deseja ver a media: ");
    string nomeDaBanda = Console.ReadLine();

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        //Metodo Ensinado

        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"\nA media da banda {nomeDaBanda} e {notasDaBanda.Average()}");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();

        //Metodo que eu pesquisei e consegui fazer 

        /*foreach(var banda in bandasRegistradas)
         {
             int soma = 0;
             for (int i = 0; i < banda.Value.Count; i++)
             {
                 soma += banda.Value[i];
             }
             int media = soma /banda.Value.Count;
             Console.WriteLine($"A nota da banda {nomeDaBanda} e {media}");
             Console.WriteLine("Digite uma tecla para voltar ao menu principal");
             Console.ReadKey();
             Console.Clear();
             ExibirOpcoesDoMenu();
            */
    }



    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} nao foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao Menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}




    ExibirLogo();
ExibirOpcoesDoMenu();