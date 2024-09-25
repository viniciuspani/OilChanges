using OilChanges.Context;
using OilChanges.Shared.Model;

namespace OilChanges.Repository.Interface
{
    public class OleoRepository : Repository<Oleo>, IOleoRepository
    {
        public OleoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
