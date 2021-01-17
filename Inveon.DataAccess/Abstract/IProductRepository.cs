using Inveon.Entities.Concrete.Dto;
using System;
using System.Collections.Generic;

namespace Inveon.DataAccess.Abstract
{
    public interface IProductRepository
    {
        List<ProductDto> Products();
        ProductDto ProductDetail(long productId);
        bool AddProduct(ProductDto product);
        bool UpdateProduct(ProductDto product);
        bool DeleteProduct(long productId);
        Tuple<bool, string> DeleteImage(long imageId);
    }
}
