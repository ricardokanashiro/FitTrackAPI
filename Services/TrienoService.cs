using FitTrackAPI.Exceptions;
using FitTrackAPI.Model;
using FitTrackAPI.Repositories;
using System;

public class TreinoService
{
	private ITreinoRepository _repository;

	public TreinoService(ITreinoRepository repository)
	{
		_repository = repository;
	}

	public async Task<IEnumerable<Treino>> ListarTreinos()
	{
		return await _repository.GetAll();
	}

	public async Task<Treino?> BuscarTreinoById(Guid id)
	{
		return await _repository.GetById(id);
	}

	public async Task CadastrarTreino(Guid alunoid, string titulo)
	{
		if(string.IsNullOrEmpty(titulo))
		{
			throw new ValidationException("Título Inválido!");
		}

		var newTreino = new Treino(alunoid, titulo);
		await _repository.Register(newTreino);
	}

	public async Task AtualizarTreino(Guid id, string titulo)
	{
        if (string.IsNullOrEmpty(titulo))
        {
            throw new ValidationException("Título Inválido!");
        }

		await _repository.Update(id, titulo);
    }

	public async Task DeletarTreino(Guid id)
	{
		await _repository.Delete(id);
	}
}
