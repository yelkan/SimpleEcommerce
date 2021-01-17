using Inveon.DataAccess.Abstract;
using Inveon.Entities.Concrete.Dto;
using Inveon.Services.Abstract;
using System;
using System.Collections.Generic;

namespace Inveon.Services.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepo;
        
        public ProductManager(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public List<ProductDto> Products()
        {
            return _productRepo.Products();
        }

        public ProductDto ProductDetail(long productId)
        {
            return _productRepo.ProductDetail(productId);
        }

        public bool AddProduct(ProductDto product)
        {
            return _productRepo.AddProduct(product);
        }

        public bool UpdateProduct(ProductDto product)
        {
            return _productRepo.UpdateProduct(product);
        }

        public bool DeleteProduct(long productId)
        {
            return _productRepo.DeleteProduct(productId);
        }
        public Tuple<bool, string> DeleteImage(long imageId)
        {
            return _productRepo.DeleteImage(imageId);
        }
    }
}
