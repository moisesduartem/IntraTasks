using IntraTasks.DataAccess.ValueObjects;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntraTasks.DataAccess.Domain
{
    public class Tarefa : BaseEntity
    {
        [MinLength(5, ErrorMessage = ErrorMessages.MinLength)]
        [MaxLength(60, ErrorMessage = ErrorMessages.MaxLength)]
        [Required(ErrorMessage = ErrorMessages.Required)]
        public string Titulo { get; set; }

        [MinLength(10, ErrorMessage = ErrorMessages.MinLength)]
        [MaxLength(180, ErrorMessage = ErrorMessages.MaxLength)]
        public string Observacao { get; set; }
        public SituacaoTarefa Situacao { get; set; } = SituacaoTarefa.Pendente;

        [ForeignKey("Membro")]
        [Required(ErrorMessage = ErrorMessages.Required)]
        public int ResponsavelId { get; set; }
        public Membro Responsavel { get; set; }

        /*
        [Required(ErrorMessage = ErrorMessages.Required)]
        public int AutorId { get; set; }
        public Membro Autor { get; set; }
        */

        [Required(ErrorMessage = ErrorMessages.Required)]
        public DateTime? Prazo { get; set; }
    }
}
