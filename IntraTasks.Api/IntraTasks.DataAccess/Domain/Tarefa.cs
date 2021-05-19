using IntraTasks.DataAccess.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;

namespace IntraTasks.DataAccess.Domain
{
    public class Tarefa : BaseEntity
    {
        [MinLength(5)]
        [MaxLength(60)]
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public string Titulo { get; set; }
        [MinLength(10)]
        [MaxLength(180)]
        public string Observacao { get; set; }
        public SituacaoTarefa Situacao { get; set; } = SituacaoTarefa.Pendente;
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public int ResponsavelId { get; set; }
        public Membro Responsavel { get; set; }
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public int AutorId { get; set; }
        public Membro Autor { get; set; }
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public DateTime Prazo { get; set; }
    }
}
