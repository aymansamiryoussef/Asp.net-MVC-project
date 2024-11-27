using BusinessLayer.Interface;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WEBDEMO.Controllers
{
    public class CategoryController : Controller
    {   
        private readonly ICategoryReprosatory _categoryReprosatory;
        public CategoryController(ICategoryReprosatory categoryReprosatory) { 
        
            _categoryReprosatory = categoryReprosatory;
        
        }
        [HttpGet]
        public ActionResult Add() {
        
            return View ("ADDCategory");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(Category category) {

                _categoryReprosatory.AddCategory(category);
            return RedirectToAction("Index", "Category");
        }
        public IActionResult Index()
        {
            List<Category>list = _categoryReprosatory.GetAllCategories();
            return View("CategoryList",list);
        }
        public IActionResult DeleteCategory(string cat)
        {
            _categoryReprosatory.DeleteCategory(cat);
            return RedirectToAction("Index", "Category");
        }
    }
}
