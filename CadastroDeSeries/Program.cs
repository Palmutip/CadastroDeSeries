using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroDeSeries.Classes;
using CadastroDeSeries.Enum;

namespace CadastroDeSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaousuario = ObterOpcaoUsuario();

            while(opcaousuario.ToUpper() != "X")
            {
                switch (opcaousuario)
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
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaousuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos servicos.");
            Console.ReadLine();
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradagenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradatitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaano = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradadescricao = Console.ReadLine();

            Serie atualizaserie = new Serie(id: indiceSerie,
                genero: (Genero)entradagenero,
                titulo: entradatitulo,
                descricao: entradadescricao,
                ano: entradaano);
            repositorio.Atualiza(indiceSerie, atualizaserie);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach(int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradagenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradatitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaano = int.Parse(Console.ReadLine());
            
            Console.Write("Digite a Descrição da Série: ");
            string entradadescricao = Console.ReadLine();

            Serie novaserie = new Serie(id: repositorio.ProximoId(),
                genero: (Genero)entradagenero,
                titulo: entradatitulo,
                descricao: entradadescricao,
                ano: entradaano);
            repositorio.Insere(novaserie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? "*Excluido*" : string.Empty);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a a opção desejada:");
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");

            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaousuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaousuario;
        }
    }
}
