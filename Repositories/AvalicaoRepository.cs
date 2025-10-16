using FitTrackAPI.Database;
using FitTrackAPI.Model;
using Microsoft.EntityFrameworkCore;
using FitTrackAPI.Exceptions;

namespace FitTrackAPI.Repositories
{
    public interface IAvaliacaoRepository
    {
        Task<IEnumerable<Avaliacao>> GetAll();
        Task<Avaliacao?> GetById(Guid id);
        Task AddAsync(Avaliacao avaliacao);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Guid id, string comentarios);
    }

    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly FitTrackDbContext _context;

        public AvaliacaoRepository(FitTrackDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Avaliacao>> GetAll()
        {
            return await _context.Avaliacoes.ToListAsync();
        }

        public async Task<Avaliacao?> GetById(Guid id)
        {
            return await _context.Avaliacoes.FindAsync(id);
        }

        public async Task AddAsync(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var avaliacaoSelected = await GetById(id);

            if(avaliacaoSelected != null)
            {
                _context.Avaliacoes.Remove(avaliacaoSelected);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Guid id, string comentarios)
        {
            var avaliacaoSelected = await GetById(id);

            if (avaliacaoSelected != null)
            {
                avaliacaoSelected.AtualizarComentarios(comentarios);
                await _context.SaveChangesAsync();
            }
        }
    }
}
