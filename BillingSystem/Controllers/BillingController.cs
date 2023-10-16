using Microsoft.AspNetCore.Mvc;

using BillingSystem.Models;
using System.Linq;

namespace BillingSystem.Controllers
{
    public class BillingController : Controller
    {
        private readonly BillingContext _context;

        public BillingController(BillingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(BillRecord record)
        {
            if (ModelState.IsValid)
            {
                _context.BillRecords.Add(record);
                _context.SaveChanges();
                return RedirectToAction("Records");
            }
            return View(record);
        }

        public IActionResult Records()
        {
            return View(_context.BillRecords.ToList());
        }
    }
}

