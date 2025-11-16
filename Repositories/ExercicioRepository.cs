using FitTrackAPI.Database;
using FitTrackAPI.DTOs;
using FitTrackAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FitTrackAPI.Repositories
{
    public interface IExercicioRepository
    {
        Task<IEnumerable<Exercicio>> GetAll();
        Task<Exercicio?> GetById(Guid id);
        Task Register(Exercicio exercicio);
        Task Update(Guid id, ExercicioUpdateDTO data);
        Task Delete(Guid id);
        Task<Exercicio?> GetByName(string nome);
    }

    public class ExercicioRepository : IExercicioRepository
    {
        private FitTrackDbContext _context;

        public ExercicioRepository(FitTrackDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Exercicio>> GetAll()
        {
            return await _context.Exercicios.ToListAsync();
        }

        public async Task<Exercicio?> GetById(Guid id)
        {
            return await _context.Exercicios.FindAsync(id);
        }

        public async Task Register(Exercicio exercicio)
        {
            _context.Exercicios.Add(exercicio);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, ExercicioUpdateDTO data)
        {
            var selectedExercicio = await GetById(id);

            if(selectedExercicio == null)
            {
                throw new Exception("Exercício não encontrado!");
            }

            selectedExercicio.AtualizarNome(data.Nome);
            selectedExercicio.AtualizarDescricao(data.Descricao);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var selectedExercicio = await GetById(id);

            if(selectedExercicio == null)
            {
                throw new Exception("Exercício não encontrado!");
            }

            _context.Exercicios.Remove(selectedExercicio);
            await _context.SaveChangesAsync();
        }

        public async Task<Exercicio?> GetByName(string nome)
        {
            return await _context.Exercicios.FirstOrDefaultAsync(e => e.Nome.ToLower() == nome.ToLower());
        }
    }
}
