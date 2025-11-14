using FitTrackAPI.Database;
using FitTrackAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Runtime.InteropServices;

namespace FitTrackAPI.Repositories
{
    public interface ITreinoRepository
    {
        Task<IEnumerable<Treino>> GetAll();
        Task<Treino?> GetById(Guid id);
        Task Register(Treino treino);
        Task Update(Guid id, string titulo);
        Task Delete(Guid id);
    }

    public class TreinoRepository
    {
        private FitTrackDbContext _context;

        public TreinoRepository(FitTrackDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Treino>> GetAll()
        {
            return await _context.Treinos.ToListAsync();
        }

        public async Task<Treino?> GetById(Guid id)
        {
            return await _context.Treinos.FindAsync(id);
        }

        public async Task Register(Treino treino)
        {       
            _context.Treinos.Add(treino);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, string titulo)
        {
            var treinoSelected = await GetById(id);

            if (treinoSelected == null)
            {
                throw new Exception("Treino não encontrado!");
            }

            treinoSelected.AtualizarTitulo(titulo);
            await _context.SaveChangesAsync();
        }
    }
}
