using IntraTasks.DataAccess.Domain;
using Microsoft.EntityFrameworkCore;

namespace IntraTasks.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Membro> Membros { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
