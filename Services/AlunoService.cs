using FitTrackAPI.Exceptions;
using FitTrackAPI.Model;
using FitTrackAPI.Repositories;

namespace FitTrackAPI.Services
{
    public class AlunoService
    {
        private readonly IAlunoRepository _repository;

        public AlunoService(IAlunoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Aluno>> ListarAlunos()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Aluno?> BuscarAlunoById(Guid id)
        {
            var foundAluno = await _repository.GetByIdAsync(id);

            if(foundAluno == null)
            {
                throw new NotFoundException("Aluno não encontrado!");
            }

            return await _repository.GetByIdAsync(id);
        }

        public async Task<Aluno> CadastrarAluno(string nome, string email)
        {
            if(string.IsNullOrEmpty(nome))
            {
                throw new ValidationException("Nome inválido!");
            }

            if(string.IsNullOrEmpty(email))
            {
                throw new ValidationException("Email inválido!");
            }
            
            var novoAluno = new Aluno(nome, email);
            await _repository.AddAsync(novoAluno);

            return novoAluno;
        }

        public async Task<Aluno> AtualizarAluno(Guid id, string nome, string email, bool ativo)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new ValidationException("Nome inválido!");
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new ValidationException("Email inválido!");
            }

            var alunoSelected = await _repository.GetByIdAsync(id);

            if(alunoSelected == null)
            {
                throw new NotFoundException("Usuário com esse id não existe");
            }

            await _repository.UpdateAsync(id, nome, email, ativo);
            return alunoSelected;
        }

        public async Task DeletarAluno(Guid id)
        {
            var alunoSelected = _repository.GetByIdAsync(id);

            if(alunoSelected == null)
            {
                throw new NotFoundException("Usuário com esse id não existe");
            }

            await _repository.DeleteAsync(id);
        }
    }
}
