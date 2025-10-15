namespace FitTrackAPI.Model
{
    public class ExecucaoExercicio
    {
        public Guid Id { get; init; }
        public int? Repeticoes { get; private set; }
        public double? Peso { get; private set; }

        public Guid SessaoTreinoId { get; private set; }
        public SessaoTreino SessaoTreino { get; set; }

        public Guid ExercicioId { get; private set; }
        public Exercicio Exercicio { get; set; }

        private ExecucaoExercicio() { } // EF

        public ExecucaoExercicio(Guid sessaoTreinoId, Guid exercicioId, int? repeticoes, double? peso)
        {
            SessaoTreinoId = sessaoTreinoId;
            ExercicioId = exercicioId;
            Repeticoes = repeticoes;
            Peso = peso;
        }
    }   
}
