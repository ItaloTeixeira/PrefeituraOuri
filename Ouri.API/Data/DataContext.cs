using Microsoft.EntityFrameworkCore;
using Ouri.API.Model;

namespace Ouri.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){
            
        }
        public DbSet<Escola> Escolas {get; set;}
      //  public DbSet<Turma> Turmas {get; set;}
    }
}