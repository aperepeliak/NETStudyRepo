using ST.Core;
using ST.Core.Models;
using ST.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace ST.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Skills(int categoryId = 0, int page = 1)
        {
            var skills = categoryId == 0
                ? _unitOfWork.Skills.GetAll().ToList()
                : _unitOfWork.Skills.GetSkillsByCategory(categoryId).ToList();

            string selectedCategoryName = categoryId == 0
                ? "Filter By Category"
                : _unitOfWork.Categories.GetCategoryById(categoryId).Name;

            int numberOfItemsPerPage = 10;
            var viewModel = new SkillsViewModel
            {
                Skills = skills.ToPagedList(page, numberOfItemsPerPage),
                Categories = _unitOfWork.Categories.GetAll().ToList(),
                SelectedCategoryName = selectedCategoryName,
                SelectedCategoryId = categoryId
            };

            return View(viewModel);
        }

        public ActionResult Index() => RedirectToAction("Skills");

        public ActionResult Categories()
        {
            var categories = _unitOfWork.Categories.GetAll().ToList();

            return View(categories);
        }

        public ActionResult Developers()
        {
            return Content("Developers");
        }

        public ActionResult Managers()
        {
            return Content("Managers");
        }
    }
}