using BusinessLayer.Interface;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEBDEMO.Controllers
{
    public class ProudctController : Controller
    {
        private readonly IProudctReprository proudctReprository;
        private readonly ICategoryReprosatory categoryReprosatory;
        public ProudctController(IProudctReprository _proudectReprository, ICategoryReprosatory _categoryReprosatory) { 
        
            proudctReprository = _proudectReprository;
            categoryReprosatory = _categoryReprosatory;

        
        }
        public IActionResult Index()
        {
            ViewBag.catogeryNames= categoryReprosatory.GetAllCategories();
            List<Proudct> products = proudctReprository.GetAll();

            return View("PROUDCTS", products);
        }

        public IActionResult proudctoncatogory(int id)
        {
            List<Proudct> p = proudctReprository.ProudctonCategory(id);

            return View("CategoryItems", p);
        }
        [HttpGet]
        public IActionResult addproudct()
        {

            return View("addproudct");
                 
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public IActionResult SaveAddProudct(Proudct proudct)
        {
            if(ModelState.IsValid)
            {
                proudctReprository.add(proudct);
                return RedirectToAction("adminIndex", "Proudct");

            }

            return View("addproudct", proudct);

        }
        
        [Authorize(Roles = "admin")]
    
        public IActionResult  UpdateProudct(int id )
        {
            var proudct = proudctReprository.GetByID(id);

            return View("UpdateView",proudct);
        }
        public IActionResult adminIndex()
        {
            ViewBag.catogeryNames = categoryReprosatory.GetAllCategories();
            List<Proudct> products = proudctReprository.GetAll();

            return View("adminProudct", products);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public IActionResult SaveUpdateProudct(int id ,Proudct proudct) {
            
            if(ModelState.IsValid)
            {
                proudctReprository.update(id, proudct);
                return RedirectToAction("adminIndex");
            }
            return View("UpdateView", proudct);
        
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProudct(int id)
        {
            proudctReprository.remove(id);
            return RedirectToAction("adminIndex");
        }
    }
}
