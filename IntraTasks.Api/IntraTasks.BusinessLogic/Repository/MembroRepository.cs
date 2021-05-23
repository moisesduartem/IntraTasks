using IntraTasks.DataAccess.Context;
using IntraTasks.DataAccess.Domain;
using IntraTasks.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IntraTasks.BusinessLogic.Repository
{
    public class MembroRepository : Repository<Membro>, IMembroRepository
    {
        public MembroRepository(AppDbContext context) : base(context)
        {}

        public override IQueryable<Membro> Get()
        {
            return _context.Set<Membro>().AsNoTracking().Include(m => m.Tarefas);
        }
    }
}
