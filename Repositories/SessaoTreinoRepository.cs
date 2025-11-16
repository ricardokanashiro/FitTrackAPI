using FitTrackAPI.Database;
using FitTrackAPI.DTOs;
using FitTrackAPI.Exceptions;
using FitTrackAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FitTrackAPI.Repositories
{
    public interface ISessaoTreinoRepository
    {
        Task<IEnumerable<SessaoTreino>> GetAll();
        Task<SessaoTreino?> GetById(Guid id);
        Task Register(SessaoTreino sessaoTreino);
        Task Update(Guid id, SessaoTreinoDTO data);
    }

    public class SessaoTreinoRepository
    {
        private FitTrackDbContext _context;

        public SessaoTreinoRepository(FitTrackDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SessaoTreino>> GetAll()
        {
            return await _context.SessoesTreino.ToListAsync();
        }

        public async Task<SessaoTreino?> GetById(Guid id)
        {
            return await _context.SessoesTreino.FindAsync(id);
        }

        public async Task Register(SessaoTreino sessaoTreino)
        {
            await _context.SessoesTreino.AddAsync(sessaoTreino);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, SessaoTreinoDTO data)
        {
            var sessaoTreino = await GetById(id);

            if (sessaoTreino == null)
            {
                throw new NotFoundException("Sessão de Treino não encontrada!");
            }

            sessaoTreino.AtualizarData(data.data);
            sessaoTreino.AtualizarDuracao(data.duracao);

            _context.SessoesTreino.Update(sessaoTreino);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
        
            var sessaoTreino = await GetById(id);

            if (sessaoTreino == null)
            {
                throw new NotFoundException("Sessão de Treino não encontrada!");
            }

            _context.SessoesTreino.Remove(sessaoTreino);
            await _context.SaveChangesAsync();
        }
    }
}
