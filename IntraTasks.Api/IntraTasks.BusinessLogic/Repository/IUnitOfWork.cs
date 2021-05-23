namespace IntraTasks.BusinessLogic.Repository
{
    public interface IUnitOfWork
    {
        IMembroRepository MembroRepository { get; }
        ITarefaRepository TarefaRepository { get;  }
        void Commit();
        void Dispose();
    }
}
