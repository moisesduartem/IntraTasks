using IntraTasks.DataAccess.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IntraTasks.DataAccess.Domain
{
    public class Membro : BaseEntity
    {
        [Required(ErrorMessage = ErrorMessages.Required)]
        [MinLength(2, ErrorMessage = ErrorMessages.MinLength)]
        [MaxLength(155, ErrorMessage = ErrorMessages.MaxLength)]
        public string Nome { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        public DateTime? Nascimento { get; set; }
        public ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
    }
}
