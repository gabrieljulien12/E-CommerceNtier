using Entıtıes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectBLL.ManagerServices.Abstracs;
using ProjectBLL.ManagerServices.Concretes;
using ProjectWebApı.Models.Product.RequestModel;
using ProjectWebApı.Models.Product.ResponseModel;

namespace ProjectWebApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductManager _productmanager;
        public ProductController( IProductManager productmanager )
        {
            _productmanager = productmanager;
        }
        [HttpPost]
        public async Task<IActionResult>CreateProduct(CreateProductRequestModel item)
        {
            Product p = new()
            {
                ProductName = item.ProductName,
                UnitPrice = item.Unitprice,
                CategoryID = item.CatagoryID
            };
            string resault =  _productmanager.Add(p);
            return Ok(resault);
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts(int? catagoryıd)
        {
            List<ProductResponseModel> products;

            if(catagoryıd.HasValue)
            {
                products = _productmanager.Where(x => x.CategoryID == catagoryıd).Select(x => new ProductResponseModel
                {
                   ID = x.ID,
                   ProductName =x.ProductName,
                   UnitPrice =x.UnitPrice,
                   CatagoryName =x.Catagory.CatagoryName
                }).ToList();

            }
            else
            {
                products = _productmanager.Select(x => new ProductResponseModel
                {
                    ID = x.ID,
                    ProductName=x.ProductName,
                    UnitPrice =x.UnitPrice,
                    CatagoryName = x.Catagory.CatagoryName

                }).ToList();
            }
            return Ok(products);
        }
    }
}
