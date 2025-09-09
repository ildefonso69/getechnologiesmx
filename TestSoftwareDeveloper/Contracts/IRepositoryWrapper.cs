namespace TestSoftwareDeveloper.Contracts
{
    public interface IRepositoryWrapper
    {
        IPersonaRepository Persona { get; }
        IFacturaRepository Factura { get; }
        void Save();
    }
}
