using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScienceResearchPA.Controllers
{
    public class ScientificSchoolController : BaseApiController
    {
        // GET: ScientificSchoolController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ScientificSchoolController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ScientificSchoolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScientificSchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ScientificSchoolController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ScientificSchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ScientificSchoolController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ScientificSchoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
