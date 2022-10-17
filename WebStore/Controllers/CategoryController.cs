using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            
            IEnumerable<Category> categoryList = _db.Categories;
            return View(categoryList);
        }
    }
}
