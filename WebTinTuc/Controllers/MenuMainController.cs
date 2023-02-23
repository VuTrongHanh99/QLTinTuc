using Core.Application.Interfaces;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebTinTuc.BackEnd.Controllers
{
    public class MenuMainController : Controller
    {
        private readonly IMenuMainServices _services;
        public MenuMainController(IMenuMainServices theLoaiServices)
        {
            _services = theLoaiServices;
        }
        // GET: MenuMainController
        public async Task<ActionResult> Index()
        {
            var results = new List<MenuMainEntity>();
            results = await _services.GetAllService();
            //option 3: using Model
            return View(results);
        }

        // GET: MenuMainController/Create
        public async Task<ActionResult> Create()
        {
            var menuParent = await _services.GetServiceMenuMain(0);
            
            ViewBag.data = menuParent;

            return View();
        }

        // POST: MenuMainController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MenuMainEntity model)
        {
            try
            {
                var newBookId = await _services.AddService(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuMainController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _services.GetServiceById(id);
            return View(result);
        }

        // POST: MenuMainController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, MenuMainEntity model)
        {
            try
            {
                var result = await _services.UpdateService(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //// GET: MenuMainController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: MenuMainController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _services.DeleteService(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
