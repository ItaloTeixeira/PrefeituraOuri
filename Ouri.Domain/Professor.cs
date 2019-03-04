using System.Collections.Generic;

namespace Ouri.Domain
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Email { get; set; }

        public List<Turma> Turmas {get; set;}

        public List<ProfessorEscola> ProfessoresEscolas {get; set;}
        


    }
}