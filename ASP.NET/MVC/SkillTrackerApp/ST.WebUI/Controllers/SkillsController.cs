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
                : _unitOfWork.Categories.GetCategory(categoryId).Name;

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
                Heading = "Add a skill"
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

            return RedirectToAction("Skills", "Skills");
        }

        public ActionResult Edit(int id)
        {
            var skill = _unitOfWork.Skills.GetSkill(id);

            if (skill == null)
                return HttpNotFound();

            var viewModel = new SkillFormViewModel
            {
                Id = id,
                Name = skill.Name,
                CategoryId = skill.CategoryId,
                Categories = _unitOfWork.Categories.GetAll(),
                Heading = "Edit a skill"
            };

            return View("SkillForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(SkillFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _unitOfWork.Categories.GetAll();
                return View("SkillForm", viewModel);
            }

            var skill = _unitOfWork.Skills.GetSkill(viewModel.Id);

            if (skill == null)
                return HttpNotFound();

            skill.Update(viewModel.Name, viewModel.CategoryId);
            _unitOfWork.Complete();

            return RedirectToAction("Skills", "Skills");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var skill = _unitOfWork.Skills.GetSkill(id);

            if (skill == null)
                return HttpNotFound();

            _unitOfWork.Skills.Remove(skill);
            _unitOfWork.Complete();

            return RedirectToAction("Skills", "Skills");
        }
    }
}
