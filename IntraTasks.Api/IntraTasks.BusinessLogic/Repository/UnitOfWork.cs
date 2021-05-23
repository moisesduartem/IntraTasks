using IntraTasks.DataAccess.Context;
using System;

namespace IntraTasks.BusinessLogic.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;
        private TarefaRepository _tarefaRepository;
        private MembroRepository _membroRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IMembroRepository MembroRepository
        {
            get
            {
                return _membroRepository ??= new MembroRepository(_context);
            }
        }

        public ITarefaRepository TarefaRepository
        {
            get
            {
                return _tarefaRepository ??= new TarefaRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
