using OilChanges.Repository.Interface;

namespace OilChanges.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        //Utilizando o padrao UnitOfWork centraliza as instancias de repositorio criadas
        //em apenas um repositorio, evitando ter mais uma instancia de acesso ao banco de dados
        //e de comprometer a integridade do banco de dados com as transações salvas.
        IVeiculoRepository VeiculoRepository { get; }
        IOleoRepository OleoRepository { get; }
        IFiltroRepository FiltroRepository { get; }

        void Commit();
    }
}
