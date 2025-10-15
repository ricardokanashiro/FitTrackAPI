namespace FitTrackAPI.Model
{
    public class Avaliacao
    {
        public Guid Id { get; init; }
        public DateTime Data { get; private set; }
        public string? Comentarios { get; private set; }

        public Guid AlunoId { get; private set; }
        public Aluno Aluno { get; set; }

        public Avaliacao() { } // EF Core

        public Avaliacao(Guid alunoId, string? comentarios)
        {
            Id = Guid.NewGuid();
            AlunoId = alunoId;
            Data = DateTime.Now;
            Comentarios = comentarios;
        }
    }
}
