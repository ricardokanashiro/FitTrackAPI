namespace FitTrackAPI.Model
{
    public class Aluno
    {
        public Guid Id { get; init; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public bool Ativo { get; private set; }
    }
}
