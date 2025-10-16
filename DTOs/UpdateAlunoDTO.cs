namespace FitTrackAPI.DTOs
{
    public record UpdateAlunoDTO(
        string Nome,
        string Email,
        bool Ativo
    );
}
