using AutoMapper.Configuration.Conventions;
using Microsoft.EntityFrameworkCore;
using TestSoftwareDeveloper.Contracts;
using TestSoftwareDeveloper.Entities;
using TestSoftwareDeveloper.Entities.Models;

namespace TestSoftwareDeveloper.Repository
{
    public class PersonaRepository : RepositoryBase<Persona>, IPersonaRepository
    {
        public PersonaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Persona> GetAllPersonas()
        {
            return FindAll()
                .OrderBy(p => p.nombre)
                .ToList();
        }

        public Persona GetPersonaById(Guid idPersona)
        {
            return FindByCondition(persona => persona.idPersona.Equals(idPersona))
                .FirstOrDefault();
        }

        public Persona GetPersonaWithDetails(int idPersona)
        {
            return FindByCondition(persona => persona.idPersona.Equals(idPersona))
                .Include(fa => fa.Facturas)
                .FirstOrDefault();
        }

        public void CreatePersona(Persona persona) => Create(persona);

        public void UpdatePersona(Persona persona) => Update(persona);

        public void DeletePersona(Persona persona) => Delete(persona);

        public Persona GetPersonaWithDetails(Guid idPersona)
        {
            throw new NotImplementedException();
        }
    }
}
