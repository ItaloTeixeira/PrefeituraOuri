using System.Threading.Tasks;
using Ouri.Domain;

namespace Ouri.Repository
{
    public interface IOuriRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();     

        //EVENTOS 

        Task<Escola[]> GetAllEscolaAsyncByName(string name, bool includeProfessores);
        Task<Escola[]> GetAllEscolaAsync(bool includeProfessores);
        Task<Escola> GetEscolaAsyncById(int EscolaId, bool includeProfessores);

        Task<Professor[]> GetAllProfessoresAsyncByName(string name, bool includeEscolas);
        Task<Professor> GetProfessorAsync(int ProfessorId, bool includeEscolas);
       
    }
}