using ST.Core;
using ST.Core.Models;
using ST.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Index()
        {
            return RedirectToAction("Skills");
        }

        public ActionResult Skills(int categoryId = 0)
        {
            List<Skill> model = categoryId == 0
                ? (model = _unitOfWork.Skills.GetAll().ToList()) 
                : (model = _unitOfWork.Skills.GetSkillsByCategory(categoryId).ToList());

            if (Request.IsAjaxRequest())
                return PartialView("_Skills", model);

            return View(model);
        }

        public ActionResult Categories()
        {
            var categories = _unitOfWork.Categories.GetAll();

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