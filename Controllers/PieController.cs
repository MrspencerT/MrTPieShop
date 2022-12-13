using BethanyPieShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShop.Controllers
{
    public class PieController: Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        // constructor injection 
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            return View(_pieRepository.AllPies);
        }
    }
}
