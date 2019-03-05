using System.Collections.Generic;

namespace Ouri.API.Dtos
{
    public class ProfessorDto
    {
        
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Email { get; set; }

        public List<TurmaDto> Turmas {get; set;}

        public List<EscolaDto> Escolas {get; set;}
        

    }
}