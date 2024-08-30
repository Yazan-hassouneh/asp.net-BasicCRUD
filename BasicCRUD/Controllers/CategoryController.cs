using BasicCRUD.Data;
using BasicCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicCRUD.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _dbx;
        public CategoryController(AppDbContext dbx)
        {
            _dbx = dbx;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _dbx.Categories;

            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create(Category model)
        {
            if (!ModelState.IsValid) return View();

            _dbx.Categories.Add(model);
            _dbx.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Details(int? id)
        {
            if(id <= 0 || id == null) return NotFound();
            var category = _dbx.Categories.Find(id);
            return View(category);
        }

        public IActionResult Update(int? id)
        {
            if (id <= 0 || id == null) return NotFound();
            var category = _dbx.Categories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Update(Category model)
        {
            if (!ModelState.IsValid) return View();

            _dbx.Categories.Update(model);
            _dbx.SaveChanges();
            return RedirectToAction("Index");

        }        
        public IActionResult Delete(int? id)
        {
            if (id <= 0 || id == null) return NotFound();
            var category = _dbx.Categories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Delete(Category model)
        {
            _dbx.Categories.Remove(model);
            _dbx.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
