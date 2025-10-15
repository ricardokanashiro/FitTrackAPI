namespace FitTrackAPI.Model
{
    public class Aluno
    {
        public Guid Id { get; init; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public bool Ativo { get; private set; }

        public ICollection<Treino> Treinos { get; set; } = new List<Treino>();
        public ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();

        public Aluno() { } // EF Core

        public Aluno(string nome, string email)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Ativo = true;
        }

        public void AtualizarNome(string nome)
        {
            Nome = nome;
        }

        public void AtualizarEmail(string email)
        {
            Email = email;
        }
    }
}
