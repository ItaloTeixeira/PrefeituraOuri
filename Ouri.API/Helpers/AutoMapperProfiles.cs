using System.Linq;
using AutoMapper;
using Ouri.API.Dtos;
using Ouri.Domain;

namespace Ouri.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Escola, EscolaDto>()
                .ForMember(dest => dest.Professores, opt =>{
                    opt.MapFrom(src => src.ProfessoresEscolas.Select(x => x.Professor).ToList());
                }).ReverseMap();
             

            CreateMap<Professor, ProfessorDto>()
                 .ForMember(dest => dest.Escolas, opt =>{
                    opt.MapFrom(src => src.ProfessoresEscolas.Select(x => x.Escola).ToList());
                }).ReverseMap();

            CreateMap<Turma, TurmaDto>().ReverseMap();  
       

        }
    }
}