using Microsoft.AspNet.Identity;
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
    [Authorize(Roles = SecurityRoles.Admin)]
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(int page = 1)
        {
            int numberOfItemsPerPage = 10;

            var viewModel = _unitOfWork.AppUsers.GetAll()
                            .Select(u => new UserViewModel
                            {
                                UserName = u.FullName,
                                Email = u.Email,
                                Role = _unitOfWork.AppUsers.GetUserRole(u)
                            })
                            .ToPagedList(page, numberOfItemsPerPage);

            return View(viewModel);
        }

        [HttpDelete]
        public ActionResult Delete(string email)
        {
            var user = _unitOfWork.AppUsers.GetUserByEmail(email);

            if (user == null)
                return HttpNotFound();

            _unitOfWork.AppUsers.Remove(user);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Users");
        }
    }
}
