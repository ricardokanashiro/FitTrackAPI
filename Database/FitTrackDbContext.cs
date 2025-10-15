using FitTrackAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FitTrackAPI.Database
{
    public class FitTrackDbContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Treino> Treinos { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<SessaoTreino> SessoesTreino { get; set; }
        public DbSet<ExecucaoExercicio> ExecucoesExercicio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Banco.sqlite");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
