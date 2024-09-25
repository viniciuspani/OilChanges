using OilChanges.Context;
using OilChanges.Shared.Model;

namespace OilChanges.Repository.Interface
{
    public class FiltroRepository : Repository<Filtro>, IFiltroRepository
    {
        public FiltroRepository(AppDbContext context) : base(context)
        {
        }
    }
}
