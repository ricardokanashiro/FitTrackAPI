using FitTrackAPI.DTOs;
using FitTrackAPI.Exceptions;
using FitTrackAPI.Model;
using FitTrackAPI.Repositories;

namespace FitTrackAPI.Services
{
    public class ExercicioService
    {
        private IExercicioRepository _repository;

        public ExercicioService(IExercicioRepository repository) {
            _repository = repository;
        }

        public async Task<IEnumerable<Exercicio>> ListarTodosExercicios()
        {
            return await _repository.GetAll();
        }

        public async Task<Exercicio?> ObterExercicioPorId(Guid id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Exercicio> RegistrarExercicio(ExercicioRegisterDTO data)
        {
            if(data == null)
            {
                throw new ValidationException("Valores inválidos!");
            }

            if(string.IsNullOrEmpty(data.Nome))
            {
                throw new ValidationException("Nome do exercício é inválido!");
            }

            if(string.IsNullOrEmpty(data.Descricao))
            {
                throw new ValidationException("Descrição do exercício é inválida!");
            }

            var exercicioWithSameName = await _repository.GetByName(data.Nome);

            if(exercicioWithSameName != null)
            {
                throw new ValidationException("Já existe um exercício com esse nome!");
            }

            var newExercicio = new Exercicio(data.TreinoId, data.Nome, data.Descricao);

            await _repository.Register(newExercicio);
            return newExercicio;
        }

        public async Task<Exercicio> AtualizarExercicio(Guid id, ExercicioUpdateDTO data)
        {
            if(data == null)
            {
                throw new ValidationException("Dados inválidos!");
            }

            if(string.IsNullOrEmpty(data.Nome))
            {
                throw new ValidationException("Nome inválido!");
            }

            if(string.IsNullOrEmpty(data.Descricao))
            {
                throw new ValidationException("Descrição inválida!");
            }

            var updatedExercicio = await _repository.GetById(id);

            if (updatedExercicio == null)
            {
                throw new NotFoundException("Exercício não encontrado!");
            }

            var exercicioWithSameName = await _repository.GetByName(data.Nome);

            if(exercicioWithSameName != null && exercicioWithSameName.Id != id)
            {
                throw new ValidationException("Já existe um exercício com esse nome!");
            }

            await _repository.Update(id, data);
            return updatedExercicio;
        }

        public async Task DeletarExercicio(Guid id)
        {
            var exercicioToDelete = await _repository.GetById(id);

            if (exercicioToDelete == null)
            {
                throw new NotFoundException("Exercício não encontrado!");
            }

            await _repository.Delete(id);
        }
    }
}
