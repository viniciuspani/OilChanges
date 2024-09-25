using OilChanges.Context;
using OilChanges.Repository.Interface;

namespace OilChanges.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private VeiculoRepository _veiculoRepo;
        private OleoRepository _oleoRepo;
        private FiltroRepository _filtroRepo;
        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }        

        public IVeiculoRepository VeiculoRepository
        {
            get { return _veiculoRepo = _veiculoRepo ?? new VeiculoRepository(_context); }
        }

        public IOleoRepository OleoRepository
        {
            get { return _oleoRepo = _oleoRepo ?? new OleoRepository(_context); }
        }

        public IFiltroRepository FiltroRepository
        {
            get { return _filtroRepo = _filtroRepo ?? new FiltroRepository(_context); }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
