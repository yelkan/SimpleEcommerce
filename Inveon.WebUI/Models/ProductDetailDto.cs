using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Inveon.WebUI.Models
{
    public class ProductDetailDto : ProductSummaryDto
    {
        public int Quantity { get; set; }
        public string Description { get; set; }
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] Files { get; set; }
    }
}