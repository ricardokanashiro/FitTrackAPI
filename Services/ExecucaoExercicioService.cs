using FitTrackAPI.DTOs;
using FitTrackAPI.Exceptions;
using FitTrackAPI.Model;
using FitTrackAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FitTrackAPI.Services
{
    public class ExecucaoExercicioService
    {
        private IExecucaoExercicioRepository _repository;
        private ISessaoTreinoRepository _sessaoTreinoRepository;
        private IExercicioRepository _exercicioRepository;

        public ExecucaoExercicioService(
            IExecucaoExercicioRepository repository,
            ISessaoTreinoRepository sessaoTreinoRepository,
            IExercicioRepository exercicioRepository
        )
        {
            _repository = repository;
            _sessaoTreinoRepository = sessaoTreinoRepository;
            _exercicioRepository = exercicioRepository;
        }

        public async Task<IEnumerable<ExecucaoExercicio>> ListarExecucoesExercicio()
        {
            return await _repository.GetAll();
        }

        public async Task<ExecucaoExercicio> BuscarExecucaoExercicioPorId(Guid id)
        {
            var execucaoExercicio = await _repository.GetById(id);

            if (execucaoExercicio == null)
            {
                throw new Exception("Execução de exercício não encontrada!");
            }

            return execucaoExercicio;
        }

        public async Task<ExecucaoExercicio> RegistrarExecucaoExercicio(ExecucaoExercicioRegisterDTO data)
        {
            var sessao = await _sessaoTreinoRepository.GetById(data.SessaoTreinoId);

            if (sessao is null)
                throw new ValidationException("Sessão de treino não encontrada!");

            var exercicio = await _exercicioRepository.GetById(data.ExercicioId);

            if (exercicio is null)
                throw new ValidationException("Exercício não encontrado!");

            if (data.Repeticoes <= 0 || data.Repeticoes > 100)
                throw new ValidationException("Repetições devem estar entre 1 e 100!");

            if (data.Peso < 0 || data.Peso > 300)
                throw new ValidationException("Peso inválido. Deve estar entre 0 e 300kg!");

            var newExecucaoExercicio = new ExecucaoExercicio
            (
                data.SessaoTreinoId,
                data.ExercicioId,
                data.Repeticoes,
                data.Peso
            );

            await _repository.Register(newExecucaoExercicio);
            return newExecucaoExercicio;
        }

        public async Task DeletarExecucaoExercicio(Guid id)
        {
            var selectedExecucaoExercicio = await _repository.GetById(id);

            if(selectedExecucaoExercicio is null)
                throw new Exception("Execução de exercício não encontrada!");

            await _repository.Delete(id);
        }
    }
}
