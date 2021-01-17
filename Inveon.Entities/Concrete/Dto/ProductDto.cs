using Inveon.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Inveon.Entities.Concrete.Dto
{
    public class ProductDto
    {

        List<ImageDto> _images = new List<ImageDto>();

        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Barcode { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public ProductStatus Status { get; set; }
        public virtual List<ImageDto> Images
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
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public int Creator { get; set; }
        public int? Modifier { get; set; }

        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] Files { get; set; }
    }
}
