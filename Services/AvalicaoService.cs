using FitTrackAPI.Exceptions;
using FitTrackAPI.Model;
using FitTrackAPI.Repositories;

namespace FitTrackAPI.Services
{
    public class AvaliacaoService
    {
        private readonly IAvaliacaoRepository _repository;
        private readonly IAlunoRepository _alunoRepository;

        public AvaliacaoService(IAvaliacaoRepository repository, IAlunoRepository alunoRepository)
        {
            _repository = repository;
            _alunoRepository = alunoRepository;
        }

        public async Task<IEnumerable<Avaliacao>> ListarAvaliacoes()
        {
            return await _repository.GetAll();
        }

        public async Task<Avaliacao> BuscarAvaliacaoById(Guid id)
        {
            var avaliacao = await _repository.GetById(id);

            if(avaliacao == null)
            {
                throw new NotFoundException("Avaliação não encontrada!");
            }

            return avaliacao;
        }

        public async Task<Avaliacao> RegistrarAvaliacao(Guid alunoId, string comentarios)
        {
            if(string.IsNullOrEmpty(comentarios))
            {
                throw new ValidationException("Comentário da avaliação é inválido!");
            }

            var alunoSelected = await _alunoRepository.GetByIdAsync(alunoId);

            if(alunoSelected == null)
            {
                throw new NotFoundException("O aluno dessa avaliação não existe!");
            }

            var novaAvaliacao = new Avaliacao(alunoId, comentarios);
            await _repository.AddAsync(novaAvaliacao);

            return novaAvaliacao;
        }

        public async Task<Avaliacao> AtualizarAvaliacao(Guid id, string comentarios)
        {
            if(string.IsNullOrEmpty(comentarios))
            {
                throw new ValidationException("O comentário da avaliação é inválido!");
            }

            var avaliacaoSelected = await _repository.GetById(id);

            if(avaliacaoSelected == null)
            {
                throw new NotFoundException("A avaliação não existe!");
            }

            await _repository.UpdateAsync(id, comentarios);
            return avaliacaoSelected;
        }

        public async Task DeletarAvaliacao(Guid id)
        {
            var avaliacaoSelected = await _repository.GetById(id);

            if(avaliacaoSelected == null)
            {
                throw new NotFoundException("A avaliação não existe!");
            }

            await _repository.DeleteAsync(id);
        }
    }
}
