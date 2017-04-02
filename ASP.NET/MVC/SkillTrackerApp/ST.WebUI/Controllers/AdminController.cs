using ST.Core;
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
            var skills = _unitOfWork.Skills.GetAll();
            return View(skills);
        }

        public ActionResult Categories()
        {
            return Content("Categories");
        }

        public ActionResult Skills()
        {
            return Content("Skills");
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