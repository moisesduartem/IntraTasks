using System;
using System.ComponentModel.DataAnnotations; 

namespace IntraTasks.DataAccess.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
