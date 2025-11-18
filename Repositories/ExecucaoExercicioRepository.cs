using FitTrackAPI.Database;
using FitTrackAPI.DTOs;
using FitTrackAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace FitTrackAPI.Repositories
{
	public interface IExecucaoExercicioRepository
	{
		Task<IEnumerable<ExecucaoExercicio>> GetAll();
		Task<ExecucaoExercicio?> GetById(Guid id);
		Task Register(ExecucaoExercicio execucaoExercicio);
		Task Delete(Guid id);
    }

	public class ExecucaoExercicioRepository : IExecucaoExercicioRepository
	{
		private FitTrackDbContext _context;

		public ExecucaoExercicioRepository(FitTrackDbContext context)
		{
			_context = context;
        }

        public async Task <IEnumerable<ExecucaoExercicio>> GetAll()
		{
			return await _context.ExecucoesExercicio.ToListAsync();
        }

		public async Task<ExecucaoExercicio?> GetById(Guid id)
		{
			return await _context.ExecucoesExercicio.FindAsync(id);
        }

		public async Task Register(ExecucaoExercicio execucaoExercicio)
		{
			_context.ExecucoesExercicio.Add(execucaoExercicio);
			await _context.SaveChangesAsync();
        }

		public async Task Delete(Guid id)
		{
			var execucaoExercicio = await GetById(id);

			if (execucaoExercicio == null)
			{
				throw new Exception("Execução de exercício não encontrada!");
            }

			_context.ExecucoesExercicio.Remove(execucaoExercicio);
			await _context.SaveChangesAsync();
        }
    }
}
