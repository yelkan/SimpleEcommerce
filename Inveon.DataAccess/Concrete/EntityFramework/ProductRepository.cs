using Inveon.Core.Common;
using Inveon.DataAccess.Abstract;
using Inveon.DataAccess.Concrete.EntityFramework.Context;
using Inveon.Entities.Concrete;
using Inveon.Entities.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Inveon.DataAccess.Concrete.EntityFramework
{
    public class ProductRepository : IProductRepository
    {
        public List<ProductDto> Products()
        {
            using (var context = new InveonDbContext())
            {
                var productList= context.Products.Include(x => x.Images).ToList();
                var _productList = new List<ProductDto>();

                foreach (var product in productList)
                {
                    var dto = new ProductDto();
                    Mapper.PropertyMap(product,dto);

                    product.Images?.ForEach(i => {
                        var imageDto = new ImageDto();
                        Mapper.PropertyMap(i, imageDto);
                        dto.Images.Add(imageDto);
                    });
                    _productList.Add(dto);
                }
                return _productList;
            }
        }

        public ProductDto ProductDetail(long productId)
        {
            using (var context = new InveonDbContext())
            {
                var product = context.Products.Where(x=> x.Id==productId).Include(x=> x.Images).FirstOrDefault();
                var _product = new ProductDto();
                Mapper.PropertyMap(product, _product);

                product.Images?.ForEach(i => {
                    var imageDto = new ImageDto();
                    Mapper.PropertyMap(i, imageDto);
                    _product.Images.Add(imageDto);
                });
                return _product;
            }
        }

        public bool AddProduct(ProductDto product)
        {
            using (var context = new InveonDbContext())
            {
                try
                {
                    var _product = new Product();
                    Mapper.PropertyMap(product, _product);

                    product.Images?.ForEach(i => {
                        var imageDto = new ProductImage();
                        Mapper.PropertyMap(i, imageDto);
                        _product.Images.Add(imageDto);
                    });
                    context.Products.Add(_product);
                    context.SaveChanges();
                }
                catch 
                {
                    return false;
                }
                return true;
            }
        }

        public bool UpdateProduct(ProductDto product)
        {
            using (var context = new InveonDbContext())
            {
                try
                {
                    var exist = context.Products.Where(x => x.Id == product.Id).Include(x => x.Images).FirstOrDefault();

                    Mapper.PropertyMap(product, exist);

                    product.Images?.ForEach(i => {
                        var imageDto = new ProductImage();
                        Mapper.PropertyMap(i, imageDto);
                        exist.Images.Add(imageDto);
                    });

                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public bool DeleteProduct(long productId)
        {
            using (var context = new InveonDbContext())
            {
                try
                {
                    var exist = context.Products.Where(x => x.Id == productId)
                        .Include(x=> x.Images);

                    context.Products.RemoveRange(exist);
                    context.SaveChanges();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
        public Tuple<bool, string> DeleteImage(long imageId)
        {
            using (var context = new InveonDbContext())
            {
                var path = string.Empty;
                try
                {
                    var exist = context.ProductImages.Where(x => x.Id == imageId);
                    path = exist.FirstOrDefault().Path;

                    context.ProductImages.RemoveRange(exist);
                    context.SaveChanges();
                }
                catch
                {
                    return new Tuple<bool, string>(false,"");
                }
                return new Tuple<bool, string>(true,path);
            }
        }
    }
}
