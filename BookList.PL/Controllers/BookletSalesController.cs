using Booklets.BLL.Interfaces;
using Booklets.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Booklets.PL.Controllers
{
    public class BookletSalesController : Controller
    {
        private readonly IBookletSalesRepository _bookletRepository;

        public BookletSalesController(IBookletSalesRepository bookletRepository)
        {
            _bookletRepository = bookletRepository;
        }
        public IActionResult Index()
        {


            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookletSales booklet)
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
        public IActionResult Edit([FromRoute] int id, BookletSales bookletSales)
        {
            if (id != bookletSales.ID)
                return BadRequest();
            if (ModelState.IsValid) // Server Side Validation
            {
                try
                {
                    _bookletRepository.Edit(bookletSales);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(bookletSales);
                }
            }

            return View(bookletSales);
        }

        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(int? id, BookletSales bookletSales)
        {
            if (id != bookletSales.ID)
                return BadRequest();
            try
            {
                _bookletRepository.Delete(bookletSales);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(bookletSales);
            }
        }

        public ActionResult GetAll()
        {
            var list = _bookletRepository.GetAll();
            return View(list);
        }
        public ActionResult Report()
        {
            var list = _bookletRepository.GetAll();
            return View(list);
        }
    }
}
