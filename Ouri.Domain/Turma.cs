namespace Ouri.Domain
{
    public class Turma
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int? EscolaId { get; set; }
        public Escola Escola { get;} 
        public int? ProfessorId { get; set; }
        public Professor Professor { get; }
    }
}