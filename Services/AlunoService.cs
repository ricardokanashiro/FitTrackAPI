using FitTrackAPI.Model;
using FitTrackAPI.Repositories;
using System.ComponentModel.DataAnnotations;

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
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Aluno>> CadastrarAluno(string nome, string email)
        {
            if(string.IsNullOrEmpty(nome))
            {
                throw new Exception("Nome inválido!");
            }

            if(string.IsNullOrEmpty(email))
            {
                throw new Exception("Email inválido!");
            }
            
            var novoAluno = new Aluno(nome, email);
            await _repository.AddAsync(novoAluno);

            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<Aluno>> AtualizarAluno(Guid id, string nome, string email, bool ativo)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new Exception("Nome inválido!");
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("Email inválido!");
            }

            await _repository.UpdateAsync(id, nome, email, ativo);
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<Aluno>> DeletarAluno(Guid id)
        {
            await _repository.DeleteAsync(id);
            return await _repository.GetAllAsync();
        }
    }
}
