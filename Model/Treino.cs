using System.Text.Json.Serialization;

namespace FitTrackAPI.Model
{
    public class Treino
    {
        public Guid Id { get; init; }
        public string Titulo { get; private set; }

        public Guid AlunoId { get; private set; }

        [JsonIgnore]
        public Aluno Aluno { get; set; }

        [JsonIgnore]
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
