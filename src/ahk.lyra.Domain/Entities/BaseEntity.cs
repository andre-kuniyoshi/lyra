using System.ComponentModel.DataAnnotations;

namespace ahk.lyra.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; private set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
