using IntraTasks.DataAccess.Context;
using IntraTasks.DataAccess.Domain;
using IntraTasks.DataAccess.Repository;
using System.Collections.Generic;
using System.Linq;

namespace IntraTasks.BusinessLogic.Repository
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(AppDbContext context) : base(context)
        {}

        public IEnumerable<Tarefa> GetTarefaByAutorId(int autorId)
        {
            return Get().Where(tarefa => tarefa.AutorId == autorId);
        }
    }
}
