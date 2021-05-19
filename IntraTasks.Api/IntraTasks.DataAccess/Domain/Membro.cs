using IntraTasks.DataAccess.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IntraTasks.DataAccess.Domain
{
    public class Membro : BaseEntity
    {
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [MinLength(2)]
        [MaxLength(155)]
        public string Nome { get; set; }
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public DateTime Nascimento { get; set; }
        public ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
    }
}
