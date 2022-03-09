using GerenciadorDeAniversários.Repo;

namespace GerenciadorDeAniversários
{
    class Program
    {
        static void Main(string[] args)
        {
            GerenciarAniversarios();
        }

        private static void GerenciarAniversarios()
        {
            int opcao;

            do
            {
                Console.Write("Menu Principal\n\n" +
                        "1 - Pesquisar Pessoas\n" +
                        "2 - Adicionar Nova Pessoa\n" +
                        "0 - Sair\n\n" +
                        "Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            Console.Clear();
                            PessoaRepo.PesquisarPessoas();
                            break;
                        case 2:
                            Console.Clear();
                            PessoaRepo.AdicionarPessoa();
                            break;
                        case 0:
                            Console.WriteLine("Você encerrou a sessão.");
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Opção Inválida!!\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção Inválida!!\n");
                }
            }
            while (opcao != 0);
        }
    }
}