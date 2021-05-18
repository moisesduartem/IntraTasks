using System;

namespace IntraTasks.DataAccess.Domain
{
    public class Tarefa : BaseEntity
    {
        public string Titulo { get; set; }
        public string Observacao { get; set; }
        public int Situacao { get; set; }
        public int ResponsavelId { get; set; }
        public Membro Responsavel { get; set; }
        public int AutorId { get; set; }
        public Membro Autor { get; set; }
        public DateTime Prazo { get; set; }
    }
}
