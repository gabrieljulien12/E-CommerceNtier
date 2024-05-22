namespace ProjectWebApı.Models.Product.RequestModel
{
    public class CreateProductRequestModel
    {
        public string ProductName { get; set; }
        public decimal Unitprice { get; set; }
        public int CatagoryID { get; set; }
    }
}
