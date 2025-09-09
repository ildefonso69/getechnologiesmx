using TestSoftwareDeveloper.Contracts;
using TestSoftwareDeveloper.Entities;

namespace TestSoftwareDeveloper.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IPersonaRepository _persona;
        private IFacturaRepository _factura;
        public IPersonaRepository Persona
        {
            get
            {
                if (_persona == null)
                {
                    _persona = new PersonaRepository(_repoContext);
                }
                return _persona;
            }
        }

        public IFacturaRepository Factura
        {
            get
            {
                if (_factura == null)
                {
                    _factura = new FacturaRepository(_repoContext);
                }
                return _factura;
            }
        }

    

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}

