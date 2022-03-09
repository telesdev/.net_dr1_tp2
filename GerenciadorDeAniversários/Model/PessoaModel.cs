namespace GerenciadorDeAniversários.Model
{
    internal class Pessoa
    {
        public string nome;
        public string sobrenome;
        public DateTime dataNascimento;

        public Pessoa(string nome, string sobrenome, DateTime dataNascimento)
        {
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.dataNascimento = dataNascimento;
        }

        public string CalcularAniversario()
        {
            DateTime comemoracaoAniversario = new DateTime(DateTime.Now.Year, dataNascimento.Month, dataNascimento.Day);
            TimeSpan contagemDias = comemoracaoAniversario - DateTime.Now;

            if (contagemDias.Days > 0)
            {
                return $"Falta(m) {contagemDias.Days} dia(s) para o aniversário deste ano.";
            }
            else if (contagemDias.Days == 0)
            {
                return "Hoje é o dia do aniversário.";
            }
            else
            {
                return $"O aniversário deste ano foi há {Math.Abs(contagemDias.Days)} dia(s).";
            }
        }
    }
}
