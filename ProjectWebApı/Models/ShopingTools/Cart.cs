using Newtonsoft.Json;

namespace ProjectWebApı.Models.ShopingTools
{
    [Serializable]
    public class Cart
    {
        [JsonProperty("_mycart")]
        Dictionary<int, CartItem> _mycart;
        public Cart()
        {
            _mycart = new Dictionary<int, CartItem>();
        }
        [JsonProperty("MyCart")]
        public List<CartItem> MyCart
        {
            get
            {
                return _mycart.Values.ToList();
            }
        }
        public void AddToCart(CartItem item)
        {
            if (_mycart.ContainsKey(item.ID))
            {
                _mycart[item.ID].Amount++;
                return;
            }
            _mycart.Add(item.ID, item);
        }
        public void RemoveFromCart(int id)
        {
            if (_mycart[id].Amount > 1)
            {
                _mycart[id].Amount--;
                return;
            }
            _mycart.Remove(id);

        }
        [JsonProperty("TotalPrice")]
        public decimal? TotalPrice
        {
            get
            {
                return _mycart.Sum(x => x.Value.SubTotal);
            }
        }
    }
}
