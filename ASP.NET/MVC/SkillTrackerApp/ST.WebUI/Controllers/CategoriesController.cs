using ST.Core;
using ST.Core.Models;
using ST.WebUI.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace ST.WebUI.Controllers
{
    [Authorize(Roles = SecurityRoles.Admin)]
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitofWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var categories = _unitofWork.Categories.GetAll().ToList();
            return View(categories);
        }

        public ActionResult Create()
        {
            var viewModel = new CategoryFormViewModel
            {
                Heading = "Add a category"
            };

            return View("CategoryForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("CategoryForm", viewModel);

            var category = new Category { Name = viewModel.Name };

            _unitofWork.Categories.Add(category);
            _unitofWork.Complete();

            return RedirectToAction("Index", "Categories");
        }

        public ActionResult Edit(int id)
        {
            var category = _unitofWork.Categories.GetCategory(id);

            if (category == null)
                return HttpNotFound();

            var viewModel = new CategoryFormViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Heading = "Edit category"
            };

            return View("CategoryForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CategoryFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("CategoryForm", viewModel);

            var category = _unitofWork.Categories.GetCategory(viewModel.Id);

            if (category == null)
                return HttpNotFound();

            category.Update(viewModel.Name);
            _unitofWork.Complete();

            return RedirectToAction("Index", "Categories");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var category = _unitofWork.Categories.GetCategory(id);

            if (category == null)
                return HttpNotFound();

            _unitofWork.Categories.Remove(category);
            _unitofWork.Complete();

            return RedirectToAction("Index", "Categories");
        }
    }
}
