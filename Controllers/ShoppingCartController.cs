using BethanyPieShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShop.Controllers
{
    public class ShoppingCartController: Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IShoppingCart shoppingCart, IPieRepository pieRepository)
        {
            _shoppingCart = shoppingCart;
            _pieRepository = pieRepository;
        }
    }
}
