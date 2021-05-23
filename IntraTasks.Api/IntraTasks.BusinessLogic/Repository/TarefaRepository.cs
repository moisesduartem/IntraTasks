using IntraTasks.DataAccess.Context;
using IntraTasks.DataAccess.Domain;
using IntraTasks.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IntraTasks.BusinessLogic.Repository
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(AppDbContext context) : base(context)
        { }

        public IEnumerable<Tarefa> GetTarefasByResponsavelId(int responsavelId)
        {
            return Get().Where(tarefa => tarefa.ResponsavelId == responsavelId);
        }

        public override IQueryable<Tarefa> Get()
        {
            return _context.Set<Tarefa>().AsNoTracking().Include(t => t.Responsavel);
        }
    }
}
