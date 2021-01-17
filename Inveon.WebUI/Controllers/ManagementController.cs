using Inveon.Core.Common;
using Inveon.Core.Common.Extensions;
using Inveon.Entities.Concrete.Dto;
using Inveon.Services.Abstract;
using Inveon.WebUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Inveon.WebUI.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class ManagementController : Controller
    {
        private IProductService _productService;
        public ManagementController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult Index()
        {
            var model = _productService.Products();

            ViewBag.Message = "Inveon Ecommerce Procudts";

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductDetailDto model)
        {
            if (model == null)
                return View("Error");
            List<ProductImageDto> images = UploadImage(model);

            model.Images = images;

            var dto = new ProductDto();
            Mapper.PropertyMap(model, dto);

            model.Images?.ForEach(i =>
            {
                var imageDto = new ImageDto();
                Mapper.PropertyMap(i, imageDto);
                dto.Images.Add(imageDto);
            });

            var result = _productService.AddProduct(dto);

            if (result)
            {
                return RedirectToAction("Index", "Management");
            }

            ModelState.AddModelError("", "Invalid Process");
            return View();
        }

        public ActionResult Update(long id)
        {
            var model = _productService.ProductDetail(id);

            if (model == null)
                return View("Error");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ProductDetailDto model)
        {
            if (model == null)
                return View("Error");

            List<ProductImageDto> images = UploadImage(model);

            model.Images = images;

            var dto = new ProductDto();
            Mapper.PropertyMap(model, dto);

            model.Images?.ForEach(i =>
            {
                var imageDto = new ImageDto();
                Mapper.PropertyMap(i, imageDto);
                dto.Images.Add(imageDto);
            });

            var result = _productService.UpdateProduct(dto);

            if (result)
            {
                return RedirectToAction("Index", "Management");
            }

            ModelState.AddModelError("", "Invalid Process");
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            if (id == 0)
                return View("Error");

            var result = _productService.DeleteProduct(id);

            if (result)
            {
                return RedirectToAction("Index", "Management");
            }

            ModelState.AddModelError("", "Invalid Process");
            return View();
        }

        public JsonResult DeleteImage(long id)
        {
            if (id == 0)
                return Json(false, JsonRequestBehavior.AllowGet);

            var result = _productService.DeleteImage(id);

            if (!result.Item1)
                return Json(false, JsonRequestBehavior.AllowGet);

            return Json(DeleteImage(result.Item2), JsonRequestBehavior.AllowGet);
        }

        private bool DeleteImage(string path)
        {
            if (path == "")
                return false;
            var rootFolder=Server.MapPath("/Content/ProductImages/");

            try
            {
                if (System.IO.File.Exists(Path.Combine(rootFolder, path)))
                {
                    System.IO.File.Delete(Path.Combine(rootFolder, path));
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        private List<ProductImageDto> UploadImage(ProductDetailDto model)
        {
            var images = new List<ProductImageDto>();

            if (!model.Files.IsNotNullAndAny())
                return images;

            foreach (var file in model.Files)
            {
                var imageName = Guid.NewGuid() + ".jpg";

                var subPath = "~/Content/ProductImages/";
                bool exists = Directory.Exists(Server.MapPath(subPath));

                if (!exists)
                    Directory.CreateDirectory(Server.MapPath(subPath));

                var url = Path.Combine(Server.MapPath(subPath + imageName));
                file.SaveAs(url);

                images.Add(
                    new ProductImageDto()
                    {
                        Name = model.Name,
                        Path = imageName
                    });
            }
            return images;
        }
    }
}