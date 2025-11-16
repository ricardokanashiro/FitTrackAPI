namespace FitTrackAPI.DTOs
{
    public record SessaoTreinoDTO (
        Guid treinoId,
        TimeSpan duracao,
        DateTime data
    );
}
