using OnlineShop.Data;

namespace OnlineShop.ViewModel
{
    public class ProductCartViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
    }
}
