using Booklets.BLL.Interfaces;
using Booklets.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Booklets.PL.Controllers
{
    public class BookletController : Controller
    {
        private readonly IBookletRepository _bookletRepository;

        public BookletController(IBookletRepository bookletRepository)
        {
            _bookletRepository = bookletRepository;
        }
        public  IActionResult Index()
        {
            
            
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Booklet booklet)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                _bookletRepository.Add(booklet);
                return RedirectToAction("Index");
            }
            return View(booklet);
        }

        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (id == null)
                return NotFound();
            var booklet = _bookletRepository.GetOne(id.Value);
            if (booklet == null)
                return NotFound();

            return View(viewName, booklet);
        }
        // Department/Edit/10
        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Booklet booklet)
        {
            if (id != booklet.BookletID)
                return BadRequest();
            if (ModelState.IsValid) // Server Side Validation
            {
                try
                {
                    _bookletRepository.Edit(booklet);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(booklet);
                }
            }

            return View(booklet);
        }

        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(int? id, Booklet booklet)
        {
            if (id != booklet.BookletID)
                return BadRequest();
            try
            {
                _bookletRepository.Delete(booklet);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(booklet);
            }
        }

        public ActionResult GetAll()
        {
            var list = _bookletRepository.GetAll();
            return View(list);
        }
    }
}
