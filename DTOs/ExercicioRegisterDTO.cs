namespace FitTrackAPI.DTOs
{
    public record ExercicioRegisterDTO(
        Guid TreinoId,
        string Nome,
        string Descricao
    );
}
