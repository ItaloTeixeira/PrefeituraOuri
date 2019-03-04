using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ouri.Domain;

namespace Ouri.Repository
{
    public class OuriRepository : IOuriRepository
    {

       
        private readonly OuriContext _context;

        public OuriRepository(OuriContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        //GERAIS
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);  
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);  
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);  
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0; 
        }

        //ESCOLAS
        public async Task<Escola[]> GetAllEscolaAsync(bool includeProfessores = false)
        {
            IQueryable<Escola> query = _context.Escolas
                .Include(c => c.Turmas);

            if(includeProfessores){
                query = query
                .Include(pe => pe.ProfessoresEscolas)
                .ThenInclude(p => p.Professor); 

            }
            query = query.AsNoTracking()
            .OrderBy(c => c.Nome.ToLower());

            return await query.ToArrayAsync();   
        }

        public async Task<Escola[]> GetAllEscolaAsyncByName(string name, bool includeProfessores)
        {
            IQueryable<Escola> query = _context.Escolas
                .Include(c => c.Turmas);

            if(includeProfessores){
                query = query
                .Include(pe => pe.ProfessoresEscolas)
                .ThenInclude(p => p.Professor); 

            }
            query = query.AsNoTracking().Where(p => p.Nome.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();   
        }


        public async Task<Escola> GetEscolaAsyncById(int EscolaId, bool includeProfessores)
        {
             IQueryable<Escola> query = _context.Escolas
                .Include(c => c.Turmas);

            if(includeProfessores){
                query = query
                .Include(pe => pe.ProfessoresEscolas)
                .ThenInclude(p => p.Professor); 

            }
            query = query.AsNoTracking().OrderBy(c => c.Nome.ToLower())
                        .Where(c => c.Id == EscolaId);

            return await query.FirstOrDefaultAsync();  
        }

        //PROFESSORES
         public async Task<Professor> GetProfessorAsync(int ProfessorId, bool includeEscolas)
        {
            IQueryable<Professor> query = _context.Professores
                .Include(c => c.Turmas);

            if(includeEscolas){
                query = query
                .Include(pe => pe.ProfessoresEscolas)
                .ThenInclude(e => e.Escola); 

            }
            query = query.AsNoTracking().OrderBy(p => p.Nome.ToLower())
                        .Where(p => p.Id == ProfessorId);

            return await query.FirstOrDefaultAsync(); 
        }
        public async Task<Professor[]> GetAllProfessoresAsyncByName(string name, bool includeEscolas)
        {
            IQueryable<Professor> query = _context.Professores
                .Include(c => c.Turmas);

            if(includeEscolas){
                query = query
                .Include(pe => pe.ProfessoresEscolas)
                .ThenInclude(e => e.Escola); 

            }
            query = query.AsNoTracking().Where(p => p.Nome.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync(); 
        }

    }
}