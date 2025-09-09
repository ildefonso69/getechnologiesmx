using AutoMapper;
using System.Security.Principal;
using TestSoftwareDeveloper.Entities;
using TestSoftwareDeveloper.Entities.Models;

namespace TestSoftwareDeveloper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Persona, PersonaDto>();

            CreateMap<Factura, FacturaDto>();

            CreateMap<PersonaForCreationDto, Persona>();

            CreateMap<PersonaForUpdateDto, Persona>();
        }
    }
}
