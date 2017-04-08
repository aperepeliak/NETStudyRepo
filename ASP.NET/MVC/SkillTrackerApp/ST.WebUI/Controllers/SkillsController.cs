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
    public class SkillsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SkillsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Skills(int categoryId = 0, int page = 1)
        {
            int numberOfItemsPerPage = 10;

            var skills = categoryId == 0
                ? _unitOfWork.Skills.GetAll()
                                    .OrderBy(s => s.Id)
                                    .ToPagedList(page, numberOfItemsPerPage)

                : _unitOfWork.Skills.GetSkillsByCategory(categoryId)
                                    .OrderBy(s => s.Id)
                                    .ToPagedList(page, numberOfItemsPerPage);

            string selectedCategoryName = categoryId == 0
                ? "Filter By Category"
                : _unitOfWork.Categories.GetCategoryById(categoryId).Name;

            var viewModel = new SkillsViewModel
            {
                Skills = skills,
                Categories = _unitOfWork.Categories.GetAll().ToList(),
                SelectedCategoryName = selectedCategoryName,
                SelectedCategoryId = categoryId
            };

            return View(viewModel);
        }

        public ActionResult Index() => RedirectToAction("Skills");

        public ActionResult Create()
        {
            var viewModel = new SkillFormViewModel
            {
                Categories = _unitOfWork.Categories.GetAll(),
                Heading = "Add a skill",
            };

            return View("SkillForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SkillFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _unitOfWork.Categories.GetAll();
                return View("SkillForm", viewModel);
            }

            var skill = new Skill
            {
                Name = viewModel.Name,
                CategoryId = viewModel.CategoryId
            };

            _unitOfWork.Skills.Add(skill);
            _unitOfWork.Complete();

            return RedirectToAction("Skills");
        }

        // GET: Skills/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Skills/Edit/5
        [HttpPost]
        public ActionResult Update(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Skills/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Skills/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
