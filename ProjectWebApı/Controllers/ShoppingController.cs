using Entıtıes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectBLL.ManagerServices.Abstracs;
using ProjectWebApı.ExtansionClases;
using ProjectWebApı.Models.ShopingTools;

namespace ProjectWebApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        IProductManager _productManager;
        IOrderManager _orderManager;
        IOrderDetailManger _orderDetailManger;
        public ShoppingController(IProductManager productManager, IOrderManager orderManager,IOrderDetailManger orderDetailManger)
        {
            _orderDetailManger = orderDetailManger;
            _productManager = productManager;
            _orderManager = orderManager;

        }

        [HttpPost]
        public async Task<IActionResult>AddProductToCart(int id)
        {
            Cart c = HttpContext.Session.GetObject<Cart>("scart") == null ? new Cart() :
                HttpContext.Session.GetObject<Cart>("scart");
            
            Product productentity = await _productManager.FindAsync(id);

            CartItem ci = new()
            {
                ID = productentity.ID,
                Name = productentity.ProductName,
                Price = productentity.UnitPrice
            };
            c.AddToCart(ci);
            HttpContext.Session.SetObject("scart", c);
            return Ok($"{ci.Name} isimli ürün sepete eklendi");
        }

        [HttpGet]
        public async Task<IActionResult> GetCardInfo()
        {
            if(HttpContext.Session.GetObject<Cart>("scart") != null)
            {
                Cart c = HttpContext.Session.GetObject<Cart>("scart");
                return Ok(c);
            }
            return BadRequest("sepetinizde henüz bir ürün yoktur");
        }
        [HttpDelete("id")]
        public async Task<IActionResult>DeleteFromCard(int id)
        {
            if (HttpContext.Session.GetObject<Cart>("scart")!= null)
            {
                Cart c = HttpContext.Session.GetObject<Cart>("scart");
                c.RemoveFromCart(id);
                HttpContext.Session.SetObject("scart", c);
                return Ok(c);
            }
            else
            {
                return BadRequest("sepetinizde ürün bulunmamaktadır");
            }
        }



        [HttpPost("confirm")]
        public async Task<IActionResult> ConfirmOrder(string shippingadress, int? appuserıd)
        {
            if(HttpContext.Session.GetObject<Cart>("scart")!= null)
            {
                //apı banka işlemi kodlarınızı girin api dökümasyonundaki bilgilerle kullanıcının size verdigi bilgileri kontrol edin gerisinide yollayın
                Cart c = HttpContext.Session.GetObject<Cart>("scart");
                Order o = new()
                {
                    ShipingAdres = shippingadress,
                    AppuserID = appuserıd
                };
                _orderManager.Add(o);

                foreach (CartItem item in c.MyCart)
                {
                    OrderDetail od = new();
                    od.OrdersID = o.ID;
                    od.ProductID = item.ID;
                    od.Quanitly = item.Amount;
                    _orderDetailManger.Add(od);
                }
                return Ok($"siparişiniz alınmıştır ödediniz fiyat : {c.TotalPrice}");
            }
            else
            {
                return BadRequest("sepetinizde ürün bulunmamaktadır");
            }
        }


    }
}
