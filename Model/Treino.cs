namespace FitTrackAPI.Model
{
    public class Treino
    {
        public Guid Id { get; init; }
        public string Titulo { get; private set; }

        public Guid AlunoId { get; private set; }
        public Aluno Aluno { get; set; }

        public ICollection<Exercicio> Exercicios { get; set; } = new List<Exercicio>();

        private Treino() { } // EF Core

        public Treino(Guid alunoId, string titulo)
        {
            Id = Guid.NewGuid();
            AlunoId = alunoId;
            Titulo = titulo;
        }

        public void AtualizarTitulo(string titulo)
        {
            Titulo = titulo;
        }
    }
}
