using FitTrackAPI.Database;
using FitTrackAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FitTrackAPI.Repositories
{

    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> GetAllAsync();
        Task<Aluno?> GetByIdAsync(Guid id);
        Task AddAsync(Aluno aluno);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Guid id, string nome, string email, Boolean ativo);
    }

    public class AlunoRepository : IAlunoRepository
    {
        private readonly FitTrackDbContext _context;

        public AlunoRepository(FitTrackDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Aluno>> GetAllAsync()
        {
            return await _context.Alunos.ToListAsync();
        }

        public async Task<Aluno?> GetByIdAsync(Guid id)
        {
            return await _context.Alunos.FindAsync(id);
        }

        public async Task AddAsync(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var alunoSelected = await GetByIdAsync(id);

            if (alunoSelected == null)
            {
                throw new Exception("Aluno não encontrado!");
            }

            _context.Alunos.Remove(alunoSelected);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, string nome, string email, bool ativo)
        {
            var alunoSelected = await GetByIdAsync(id);

            if(alunoSelected == null)
            {
                throw new Exception("Aluno não encontrado!");
            }

            alunoSelected.AtualizarNome(nome);
            alunoSelected.AtualizarEmail(email);
            alunoSelected.AtualizarStatus(ativo);

            await _context.SaveChangesAsync();
        }
    }
}
