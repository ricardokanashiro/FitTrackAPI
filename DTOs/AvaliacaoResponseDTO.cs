using FitTrackAPI.Model;

namespace FitTrackAPI.DTOs
{
    public record AvaliacaoResponseDTO(
        Guid Id,
        string Comentarios,
        Guid AlunoId
    )
    {
        public static AvaliacaoResponseDTO FromEntity(Avaliacao avaliacao)
       => new(avaliacao.Id, avaliacao.Comentarios, avaliacao.AlunoId);
    }
}
