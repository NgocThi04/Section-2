using CoffeeShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Shop()
        {
            return View(_productRepository.GetAllProducts());
        }
    

        public IActionResult Get(int id)
        {
            var product = _productRepository.GetProductDetail(id); 
            if (product == null)
            {
                return NotFound(); 
            }
            return View(product); 
        }
        public IActionResult Trending()
        {
            var trendingProducts = _productRepository.GetTrendingProducts();
            return View(trendingProducts);
        }
    }
}