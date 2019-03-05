using System.Collections.Generic;

namespace Ouri.API.Dtos
{
    public class EscolaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Diretor { get; set; }

        public List<TurmaDto> Turmas { get; set; }

        public List<ProfessorDto> Professores{get; set;}
        
        
    }
}