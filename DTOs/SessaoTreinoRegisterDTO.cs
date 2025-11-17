namespace FitTrackAPI.DTOs
{
    public record SessaoTreinoRegisterDTO(
        Guid treinoId,
        TimeSpan duracao,
        DateTime data
    );
}
