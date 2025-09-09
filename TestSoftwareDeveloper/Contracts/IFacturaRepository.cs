using System.Security.Principal;
using TestSoftwareDeveloper.Entities.Models;

namespace TestSoftwareDeveloper.Contracts
{
    public interface IFacturaRepository
    {
        IEnumerable<Factura> FacturasByPersona(Guid idPersona);

        void CreateFactura(Factura factura);
    }
}
