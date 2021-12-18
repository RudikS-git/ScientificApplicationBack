using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScienceResearchPA.Controllers
{
    public class InfrastructureProjectController : BaseApiController
    {
        // GET: InfrastructureProjectController
        public ActionResult Index()
        {
            return View();
        }

        // GET: InfrastructureProjectController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InfrastructureProjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InfrastructureProjectController/Create
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

        // GET: InfrastructureProjectController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InfrastructureProjectController/Edit/5
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

        // GET: InfrastructureProjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InfrastructureProjectController/Delete/5
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
