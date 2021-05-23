using IntraTasks.DataAccess.Domain;
using Microsoft.EntityFrameworkCore;

namespace IntraTasks.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Membro> Membros { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
