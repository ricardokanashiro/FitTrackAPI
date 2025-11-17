using FitTrackAPI.DTOs;
using FitTrackAPI.Exceptions;
using FitTrackAPI.Model;
using FitTrackAPI.Repositories;

namespace FitTrackAPI.Services
{
    public class SessaoTreinoService
    {
        private ISessaoTreinoRepository _repository;
        private ITreinoRepository _treinoRepository;

        public SessaoTreinoService(
            ISessaoTreinoRepository sessaoTreinoRepository,
            ITreinoRepository treinoRepository
        )
        {
            _repository = sessaoTreinoRepository;
            _treinoRepository = treinoRepository;
        }

        public async Task<IEnumerable<SessaoTreino>> ListarSessoesTreino()
        {
            return await _repository.GetAll();
        }

        public async Task<SessaoTreino?> BuscarSessaoTreinoPorId(Guid id)
        {
            return await _repository.GetById(id);
        }

        public async Task<SessaoTreino> RegistrarSessaoTreino(SessaoTreinoRegisterDTO data)
        {
            if(data == null)
            {
                throw new ValidationException("Dados inválidos!");
            }

            if(data.treinoId == Guid.Empty)
            {
                throw new ValidationException("ID do treino é obrigatório!");
            }

            var treino = await _treinoRepository.GetById(data.treinoId);

            if(treino == null)
            {
                throw new NotFoundException("Treino não encontrado!");
            }

            if (data.duracao < TimeSpan.Zero)
                throw new ValidationException("Duração não pode ser negativa!");

            if (data.duracao > TimeSpan.FromHours(6))
                throw new ValidationException("A duração informada é muito longa.");

            if (data.data == default)
                throw new ValidationException("Data inválida!");

            if (data.data > DateTime.Now.AddMinutes(1))
                throw new ValidationException("Não é permitido registrar treinos no futuro.");

            var newSessaoTreino = new SessaoTreino(
                data.treinoId,
                data.duracao,
                data.data
            );

            await _repository.Register(newSessaoTreino);
            return newSessaoTreino;
        }

        public async Task<SessaoTreino> AtualizarSessaoTreino(Guid id, SessaoTreinoUpdateDTO data)
        {
            if(data == null)
                throw new ValidationException("Dados inválidos!");

            if (data.Duracao < TimeSpan.Zero)
                throw new ValidationException("Duração não pode ser negativa!");

            if (data.Duracao > TimeSpan.FromHours(6))
                throw new ValidationException("A duração informada é muito longa.");

            if (data.Data == default)
                throw new ValidationException("Data inválida!");

            if (data.Data > DateTime.Now.AddMinutes(1))
                throw new ValidationException("Não é permitido registrar treinos no futuro.");

            var selectedSessaoTreino = await _repository.GetById(id);

            if(selectedSessaoTreino == null)
                throw new NotFoundException("Sessão de Treino não encontrada!");

            await _repository.Update(id, data);

            return selectedSessaoTreino;
        }

        public async Task DeletarSessaoTreino(Guid id)
        {
            var selectedSessaoTreino = await _repository.GetById(id);

            if (selectedSessaoTreino == null)
                throw new NotFoundException("Sessão de Treino não encontrada!");

            await _repository.Delete(id);
        }
    }
}
