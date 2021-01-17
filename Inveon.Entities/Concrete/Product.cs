using Inveon.Core.Enums;
using Inveon.Entities.DbObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inveon.Entities.Concrete
{
    public class Product : DbObjectAudit<long>
    {

        List<ProductImage> _images = new List<ProductImage>();
        public string Name { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public ProductStatus Status { get; set; }
        public virtual List<ProductImage> Images
        {
            get
            {
                return _images;
            }
            set
            {
                _images = value;
            }
        }
    }
}
