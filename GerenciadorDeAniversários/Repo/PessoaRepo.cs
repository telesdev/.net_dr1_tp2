using GerenciadorDeAniversários.Model;

namespace GerenciadorDeAniversários.Repo
{
    internal class PessoaRepo
    {
        private static List<Pessoa> Pessoas = new List<Pessoa>()
        {
            new Pessoa("Thyago", "Teles", DateTime.Parse("11/05/1989")),
            new Pessoa("Candida", "Teles", DateTime.Parse("24/05/1962")),
            new Pessoa("Gabrielle", "Teles", DateTime.Parse("29/12/1996")),
            new Pessoa("Alexandre", "Ferreira", DateTime.Parse("21/07/1989")),
            new Pessoa("Fulano", "Fulano", DateTime.Now.AddDays(-1))
        };

        public static void PesquisarPessoas()
        {
            Console.WriteLine("Você escolheu **PESQUISAR PESSOAS*");

            List<Pessoa> Linq = new List<Pessoa>();

            if (Pessoas.Count >= 1)
            {
                Console.WriteLine("\nPessoas cadastradas:\n");
                foreach (var pessoa in Pessoas)
                {
                    Console.WriteLine($"{pessoa.nome} {pessoa.sobrenome}");
                }

                Console.Write("\nDigite o nome ou parte do nome de quem você busca: ");

                var busca = Console.ReadLine().ToLower();

                IEnumerable<Pessoa> consulta = Pessoas.Where(p => p.nome.ToLower().Contains(busca) || p.sobrenome.ToLower().Contains(busca));

                Console.WriteLine();

                int i = 1;

                foreach (var resultado in consulta)
                {
                    Linq.Add(resultado);
                    Console.WriteLine($"{i} - {resultado.nome} {resultado.sobrenome}");
                    i++;
                }

                if (Linq.Count >= 1)
                {
                    Console.Write("\nSelecione a opção desejada para visualizar os dados da pessoa escolhida: ");

                    if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= Linq.Count)
                    {
                        Console.WriteLine($"\nDados da pessoa escolhida:\n" +
                            $"Nome completo: {Linq[escolha - 1].nome} {Linq[escolha - 1].sobrenome}\n" +
                            $"Data de nascimento: {Linq[escolha - 1].dataNascimento:dd/MM/yyyy}\n" +
                            $"{Linq[escolha - 1].CalcularAniversario()}\n");
                    }
                    else
                    {
                        Console.WriteLine("\nOpção Inválida!!\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nA busca não encontrou resultados\n");
                }
            }
            else
            {
                Console.WriteLine("\nNão há pessoas na lista.\n");
            }
        }
        public static List<Pessoa> AdicionarPessoa()
        {
            Console.WriteLine("Você escolheu **ADICIONAR NOVA PESSOA*\n");

            Console.Write("Nome: ");
            var nome = Console.ReadLine();
            Console.Write("Sobrenome: ");
            var sobrenome = Console.ReadLine();
            Console.Write("Data de Nascimento (no formato dd/MM/yyyy): ");
            var dataNascimento = Console.ReadLine();

            if (DateTime.TryParse(dataNascimento, out DateTime parsedData))
            {
                Console.WriteLine("\nDeseja adicionar essa pessoa?\n");
                Console.WriteLine($"Nome Completo: {nome} {sobrenome}");
                Console.WriteLine($"Data do Nascimento: {parsedData:dd/MM/yyyy}\n");

                Console.Write("1 - Sim\n" +
                        "0 - Não\n" +
                        "\nEscolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out int opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            Pessoa p = new Pessoa(nome, sobrenome, DateTime.Parse(dataNascimento));
                            Pessoas.Add(p);
                            Console.WriteLine("\nDados adicionados com sucesso!\n");
                            break;
                        case 0:
                            Console.Clear();
                            AdicionarPessoa();
                            break;
                        default:
                            Console.WriteLine("\nOpção Inválida!!\n");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nFormato incorreto de data! Tente novamente.\n");
            }
            return Pessoas;
        }
    }
}
