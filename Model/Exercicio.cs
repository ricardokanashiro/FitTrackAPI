namespace FitTrackAPI.Model
{
    public class Exercicio
    {
        public Guid Id { get; init; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public Guid TreinoId { get; private set; }
        public Treino Treino { get; set; }

        private Exercicio () { } // EF Core

        public Exercicio(Guid treinoId, string nome, string descricao)
        {
            Id = Guid.NewGuid();
            TreinoId = treinoId;
            Nome = nome;
            Descricao = descricao;
        }

        public void AtualizarNome(string nome)
        {
            Nome = nome;
        }

        public void AtualizarDescricao(string descricao)
        {
            Descricao = descricao;
        }
    }
}
