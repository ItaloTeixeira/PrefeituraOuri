using System.Collections.Generic;

namespace Ouri.Domain
{
    public class Escola
    {
       

        public Escola(string nome, string cidade, string bairro, string rua, string diretor)
        {
            this.Nome = nome;
            this.Cidade = cidade;
            this.Bairro = bairro;
            this.Rua = rua;
            this.Diretor = diretor;

        }
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Diretor { get; set; }

        public List<Turma> Turmas { get; set; }

        public List<ProfessorEscola> ProfessoresEscolas {get; set;}
        



    }
}