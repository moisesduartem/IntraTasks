using System;
using System.Collections.Generic;

namespace IntraTasks.DataAccess.Domain
{
    public class Membro : BaseEntity
    {
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
    }
}
