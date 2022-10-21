using Microsoft.AspNetCore.Mvc;
using Store.DataAccess.Repository.IRepository;
using Store.Models;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubCategoryController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<SubCategory> objSubCategoryList = _unitOfWork.SubCategory.GetAll();
            return View(objSubCategoryList);
        }

        //GET action method
        public IActionResult Create()
        {
            return View();
        }

        //POST action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SubCategory obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.SubCategory.Add(obj); 
                _unitOfWork.Save();
                TempData["success"] = "SubCategory created successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET action method
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var subCategoryFromDbFirst = _unitOfWork.SubCategory.GetFirstOrDefault(u => u.Id == id);

            if (subCategoryFromDbFirst == null)
            {
                return NotFound();
            }

            return View(subCategoryFromDbFirst);
        }

        //POST action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SubCategory obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.SubCategory.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "SubCategory edited successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // Delete Method 

        //GET action method
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
           
            var subCategoryFromDbFirst = _unitOfWork.SubCategory.GetFirstOrDefault(u => u.Id == id);

            if (subCategoryFromDbFirst == null)
            {
                return NotFound();
            }

            return View(subCategoryFromDbFirst);
        }

        //POST action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.SubCategory.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.SubCategory.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "SubCategory deleted successfully!";
            return RedirectToAction("Index");
        }

    }
}
