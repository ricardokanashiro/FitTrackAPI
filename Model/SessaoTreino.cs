namespace FitTrackAPI.Model
{
    public class SessaoTreino
    {
        public Guid Id { get; init; }
        public DateTime Data { get; private set; }
        public TimeSpan Duracao { get; private set; }

        public Guid TreinoId { get; private set; }
        public Treino Treino { get; set; }

        public ICollection<ExecucaoExercicio> ExecucaoExercicios { get; set; } = new List<ExecucaoExercicio>();

        public SessaoTreino() { } // EF Core

        public SessaoTreino(Guid treinoId)
        {
            Id = Guid.NewGuid();
            Data = DateTime.Now;
            Duracao = TimeSpan.Zero;
            TreinoId = treinoId;
        }
    }
}
