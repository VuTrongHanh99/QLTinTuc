using Core.Application.Interfaces;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebTinTuc.BackEnd.Controllers
{
    public class TheLoaiController : Controller
    {
        private readonly ITheLoaiServices _services;

        public TheLoaiController(ITheLoaiServices theLoaiServices)
        {
            _services = theLoaiServices;
        }
        // GET: TheLoaiController
        public async Task<ActionResult> Index()
        {
            var results = new List<TheLoaiEntity>();
            results = await _services.GetAllService();
            //option 1: using ViewBag
            //ViewBag.Results = results;

            //option 2: using ViewData
            //ViewData["Results"] = results;

            //option 3: using Model
            return View(results);
        }

        // GET: TheLoaiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TheLoaiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TheLoaiEntity collection)
        {
            try
            {
                var newBookId = await _services.AddService(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TheLoaiController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TheLoaiController/Edit/5
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

        // GET: TheLoaiController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TheLoaiController/Delete/5
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
