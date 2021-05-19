using IntraTasks.DataAccess.Context;
using IntraTasks.DataAccess.Domain;
using IntraTasks.DataAccess.Repository;

namespace IntraTasks.BusinessLogic.Repository
{
    public class MembroRepository : Repository<Membro>, IMembroRepository
    {
        public MembroRepository(AppDbContext context) : base(context)
        { }
    }
}
