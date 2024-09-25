using OilChanges.Context;
using OilChanges.Shared.Model;

namespace OilChanges.Repository.Interface
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Veiculo> GetVeiculoMarca(string marca)
        {
            return Get().Where(m => m.Fabricante == marca);
        }
    }
}
