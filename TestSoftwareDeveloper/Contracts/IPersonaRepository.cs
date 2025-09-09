using TestSoftwareDeveloper.Entities;
using TestSoftwareDeveloper.Entities.Models;

namespace TestSoftwareDeveloper.Contracts
{
    public interface IPersonaRepository
    {
        IEnumerable<Persona> GetAllPersonas();
        Persona GetPersonaById(Guid idPersona);
        Persona GetPersonaWithDetails(Guid idPersona);
        void CreatePersona(Persona persona);
        void UpdatePersona(Persona persona);
        void DeletePersona(Persona persona);
    }
}
