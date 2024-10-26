using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using System.Runtime.CompilerServices;

namespace PieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            ViewBag.CurrentCategory = "Cheese Cakes";
            return View(_pieRepository.AllPies);
        }
    }
}
