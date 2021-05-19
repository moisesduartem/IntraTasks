using IntraTasks.DataAccess.Domain;
using IntraTasks.DataAccess.Repository;
using System.Collections.Generic;

namespace IntraTasks.BusinessLogic.Repository
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        IEnumerable<Tarefa> GetTarefaByAutorId(int autorId);
    }
}
