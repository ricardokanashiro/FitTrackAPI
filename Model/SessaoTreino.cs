using System.Text.Json.Serialization;

namespace FitTrackAPI.Model
{
    public class SessaoTreino
    {
        public Guid Id { get; init; }
        public DateTime Data { get; private set; }
        public TimeSpan Duracao { get; private set; }

        public Guid TreinoId { get; private set; }

        [JsonIgnore]
        public Treino Treino { get; set; }

        [JsonIgnore]
        public ICollection<ExecucaoExercicio> ExecucaoExercicios { get; set; } = new List<ExecucaoExercicio>();

        public SessaoTreino() { } // EF Core

        public SessaoTreino(Guid treinoId, TimeSpan duracao, DateTime date)
        {
            Id = Guid.NewGuid();
            Data = date;
            Duracao = duracao;
            TreinoId = treinoId;
        }

        public void AtualizarData(DateTime data)
        {
            Data = data;
        }

        public void AtualizarDuracao(TimeSpan duracao)
        {
            Duracao = duracao;
        }
    }
}
