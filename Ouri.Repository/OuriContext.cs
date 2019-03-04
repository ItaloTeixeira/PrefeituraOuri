using Microsoft.EntityFrameworkCore;
using Ouri.Domain;

namespace Ouri.Repository
{
    public class OuriContext : DbContext
    {
        public OuriContext(DbContextOptions<OuriContext> options) : base (options){}
        public DbSet<Escola> Escolas {get; set;}
        public DbSet<Professor> Professores { get; set; }
        public DbSet<ProfessorEscola> ProfessoresEscolas { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<ProfessorEscola>()
                .HasKey(PE => new {PE.EscolaId, PE.ProfessorId}); 
        }



     
    }
}