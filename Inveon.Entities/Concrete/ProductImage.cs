using Inveon.Entities.DbObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inveon.Entities.Concrete
{
    public class ProductImage : DbObject<long>
    {
        public long ProductId { get;set; }

        public string Name { get; set; }
        public string Path { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } 
    }
}
