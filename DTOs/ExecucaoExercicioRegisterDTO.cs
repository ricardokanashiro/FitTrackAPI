namespace FitTrackAPI.DTOs
{
    public record ExecucaoExercicioRegisterDTO(
        Guid SessaoTreinoId,
        Guid ExercicioId,
        int Repeticoes,
        double Peso
    );
}
