namespace Ouri.Domain
{
    public class ProfessorEscola
    {
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; } 
        public int EscolaId { get; set; }
        public  Escola Escola {get; set;}
    }
}