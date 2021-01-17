using Inveon.Core.Enums;
using System.Collections.Generic;

namespace Inveon.WebUI.Models
{
    public abstract class ProductSummaryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Barcode { get; set; }
        public ProductStatus Status { get; set; }
        public List<ProductImageDto> Images { get; set; }
    }
}