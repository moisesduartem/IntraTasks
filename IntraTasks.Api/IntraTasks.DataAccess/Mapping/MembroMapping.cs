using IntraTasks.DataAccess.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntraTasks.DataAccess.Mapping
{
    public class MembroMapping : IEntityTypeConfiguration<Membro>
    {
        public void Configure(EntityTypeBuilder<Membro> builder)
        {
            builder.ToTable("Membro");
            builder.HasKey(membro => membro.Id);
            builder.Property(membro => membro.Nome);
            builder.Property(membro => membro.Nascimento);
            builder.Property(membro => membro.CreatedAt).HasColumnType("datetime2");
            builder.Property(membro => membro.UpdatedAt).HasColumnType("datetime2");

            /* builder.HasMany(membro => membro.Tarefas)
                   .WithOne(tarefa => tarefa.Autor)
                   .HasForeignKey(tarefa => tarefa.AutorId); */

            builder.HasMany(membro => membro.Tarefas)
                    .WithOne(tarefa => tarefa.Responsavel)
                    .HasForeignKey(tarefa => tarefa.ResponsavelId);
        }
    }
}
