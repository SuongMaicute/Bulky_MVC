using bulkyweb.Data;
using bulkyweb.Models;
using Microsoft.AspNetCore.Mvc;

namespace bulkyweb.Controllers
{
    public class CategoryController : Controller
    {
        //BulkyDBContext db = new BulkyDBContext();   
        private readonly BulkyDBContext _db;
        public CategoryController(BulkyDBContext db)
        {
            _db = db;   
        }

        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();


            return View(categories);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder)
            {
                ModelState.AddModelError("name", "Display order cannot match the name!!!");
            }
            if(ModelState.IsValid)
            {
            _db.Categories.Add(obj); 
            _db.SaveChanges();
                TempData["success"] = "category create success fully";
                return RedirectToAction("Index", "Category");

            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id ==0)
            {
                return NotFound();
            }
            Category cate = _db.Categories.FirstOrDefault(c => c.Id == id);
            if(cate == null)
            {
                return NotFound();
            }
            return View(cate);
        }

        [HttpPost] 
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder)
            {
                ModelState.AddModelError("name", "Display order cannot match the name!!!");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "category update success fully";
                return RedirectToAction("Index", "Category");

            }
            else
            {
                return View();
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? cate = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (cate == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(cate);
            _db.SaveChanges();
            TempData["success"] = "category delete success fully";
            return RedirectToAction("Index", "Category");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? cate = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (cate == null)
            {
                return NotFound();
            }
            return View(cate);
        }
    }
}
