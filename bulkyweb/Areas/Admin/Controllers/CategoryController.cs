using Bulky.DataAccess.Repository.IRepository;
using bulkyweb.Data;
using bulkyweb.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulkyweb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        //BulkyDBContext db = new BulkyDBContext();   
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }

        public IActionResult Index()
        {
            List<Category> categories = _categoryRepo.GetAll().ToList();


            return View(categories);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder)
            {
                ModelState.AddModelError("name", "Display order cannot match the name!!!");
            }
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(obj);
                _categoryRepo.Save();
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
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category cate = _categoryRepo.Get(c => c.Id == id);
            if (cate == null)
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
                _categoryRepo.Update(obj);
                _categoryRepo.Save();
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
            Category? cate = _categoryRepo.Get(c => c.Id == id);
            if (cate == null)
            {
                return NotFound();
            }
            _categoryRepo.Remove(cate);
            _categoryRepo.Save();
            TempData["success"] = "category delete success fully";
            return RedirectToAction("Index", "Category");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? cate = _categoryRepo.Get(c => c.Id == id);
            if (cate == null)
            {
                return NotFound();
            }
            return View(cate);
        }
    }
}
