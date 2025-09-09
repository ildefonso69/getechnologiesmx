using System.Security.Principal;
using TestSoftwareDeveloper.Contracts;
using TestSoftwareDeveloper.Entities;
using TestSoftwareDeveloper.Entities.Models;

namespace TestSoftwareDeveloper.Repository
{
    public class FacturaRepository : RepositoryBase<Factura>, IFacturaRepository
    {
        public FacturaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateFactura(Factura factura)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Factura> FacturasByPersona(Guid idPersona) =>
            FindByCondition(a => a.idPersona.Equals(idPersona)).ToList();

        
    }
}
