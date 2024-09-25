using OilChanges.Shared.Model;

namespace OilChanges.Repository.Interface
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        IEnumerable<Veiculo> GetVeiculoMarca(string marca);
    }
}
