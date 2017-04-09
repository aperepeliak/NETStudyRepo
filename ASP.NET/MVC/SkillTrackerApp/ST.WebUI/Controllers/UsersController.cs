using Microsoft.AspNet.Identity;
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
    [Authorize(Roles = SecurityRoles.Admin)]
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {

            var viewModel = _unitOfWork.AppUsers
                .GetAll()
                .ToList()
                .Select(u => new UserViewModel
                {
                    UserName = u.FullName,
                    Email = u.Email,
                    Role = _unitOfWork.AppUsers.GetUserRole(u)
                });

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
