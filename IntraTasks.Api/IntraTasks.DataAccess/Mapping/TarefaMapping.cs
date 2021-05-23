using IntraTasks.DataAccess.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntraTasks.DataAccess.Mapping
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable(nameof(Tarefa));
            builder.HasKey(tarefa => tarefa.Id);
            builder.Property(tarefa => tarefa.Titulo);
            builder.Property(tarefa => tarefa.Observacao);
            builder.Property(tarefa => tarefa.Situacao)
                   .HasConversion<int>();
            builder.Property(tarefa => tarefa.Prazo).HasColumnType("datetime2");
            builder.Property(tarefa => tarefa.CreatedAt).HasColumnType("datetime2");
            builder.Property(tarefa => tarefa.UpdatedAt).HasColumnType("datetime2");

            /*  builder.HasOne(tarefa => tarefa.Autor)
                      .WithMany(autor => autor.Tarefas)
                      .HasForeignKey(tarefa => tarefa.AutorId); */

            builder.HasOne<Membro>(tarefa => tarefa.Responsavel)
                    .WithMany(responsavel => responsavel.Tarefas)
                    .HasForeignKey(tarefa => tarefa.ResponsavelId);
        }
    }
}
