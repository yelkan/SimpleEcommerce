using System.ComponentModel.DataAnnotations;

namespace Inveon.Entities.DbObjects
{
    public abstract class DbObject<T>
    {
       [Key]
       public T Id { get; set; }

    }
}
