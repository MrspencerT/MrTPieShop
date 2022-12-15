using BethanyPieShop.Models;

namespace BethanysPieShop.Controllers
{
    internal class ShoppingCartViewModel
    {
        private IShoppingCart shoppingCart;
        private decimal v;

        public ShoppingCartViewModel(IShoppingCart shoppingCart, decimal v)
        {
            this.shoppingCart = shoppingCart;
            this.v = v;
        }
    }
}