using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main (string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                       VisualizarSerie();
                        break;
                    case"C":
                        Console.Clear();
                        break;
                        
                    default: 
                    throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("Volte logo para continuar a assistir!");
        }

        private static void ExcluirSerie()
        {
            System.Console.WriteLine("Digite o Id da série que você deseja apagar: ");
            int indiceSerie = int.Parse(Console.ReadLine());            

            repositorio.Exclui(indiceSerie);

            System.Console.WriteLine("Sua série foi excluída");

        }

        private static void VisualizarSerie()
        {
            System.Console.WriteLine("Digite o Id da série que você quer ver mais detalhes: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            System.Console.WriteLine(serie);

        }

        private static void AtualizarSerie()
        {
            System.Console.WriteLine("Digite o código da série que quer atualizar? [O id do filme]");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            
            }
            System.Console.WriteLine("Selecione o gênero da série digitando o número correspondente acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o nome da série que você quer inserir no CandyMary Series");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano que essa série foi lançada: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite uma breve descrição sobre essa série: ");
            string entradaDescricao = Console.ReadLine();

            System.Console.WriteLine("Sua série foi atualizada com sucesso!! :))");

            Serie atualizarSerie = new Serie (id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizarSerie);


        }

        private static void ListarSeries()
        {
            System.Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if(lista.Count ==0)
            {
                System.Console.WriteLine("Ainda não existe essa série cadastrada! :(");
                return;
            }
            
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                System.Console.WriteLine("#ID {0}: - {1} {2}" , serie.retornaId(), serie.retornaTitulo(), (excluido ? " - *Excluído*": ""));
            }
        }          
        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir uma nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i , Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Selecione o gênero da série digitando o número correspondente acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o nome da série que você quer inserir no CandyMary Series");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano que essa série foi lançada: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite uma breve descrição sobre essa série: ");
            string entradaDescricao = Console.ReadLine();

            System.Console.WriteLine("Sua série foi adicionada com sucesso!! :))");

            Serie novaSerie = new Serie( id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
                             
        

        }


        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("CandyMary Séries pronto pra escolher a sua!!!");
            System.Console.WriteLine("Informe a opção desejada: ");

            System.Console.WriteLine("1- Listar séries");
            System.Console.WriteLine("2- Inserir nova série");
            System.Console.WriteLine("3- Atualizar série");
            System.Console.WriteLine("4- Excluir série");
            System.Console.WriteLine("5- Visualizar série");
            System.Console.WriteLine("C- Limpar tela");
            System.Console.WriteLine("X- Sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}