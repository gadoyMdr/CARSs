using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CARS.Data;
using CARS.Models;

namespace CARS.Controllers
{
    public class VehiculeTypeController : Controller
    { 

        private readonly AppDbContext _context;

        public VehiculeTypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: VehiculeType
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehiculeType.ToListAsync());
        }

        // GET: VehiculeType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculeType = await _context.VehiculeType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculeType == null)
            {
                return NotFound();
            }

            return View(vehiculeType);
        }

        // GET: VehiculeType/Create
        public IActionResult Create()
        {
            return View();
        }

        [BindProperty]
        VehiculeType VehiculeType { get; set; }

        public ActionResult Upsert(int? id)
        {
            VehiculeType = new VehiculeType();

            if (!id.HasValue)
                return View(VehiculeType);

            VehiculeType = _context.VehiculeType.Find(id);

            if (VehiculeType == null)
                return NotFound();

            return View(VehiculeType);
        }

        public ActionResult UpdateCreate([Bind("Id,Name")] VehiculeType vehiculeType)
        {
            Console.WriteLine(vehiculeType.Name);
            Console.WriteLine(vehiculeType.Id);
            if (ModelState.IsValid)
            {
                if (vehiculeType.Id == 0)
                {
                    _context.VehiculeType.Add(vehiculeType);
                }
                else
                {
                    _context.VehiculeType.Update(vehiculeType);
                }

                _context.SaveChanges();

            }
            return RedirectToAction("Index");

        }

        // POST: VehiculeType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculeType = await _context.VehiculeType.FindAsync(id);
            _context.VehiculeType.Remove(vehiculeType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculeTypeExists(int id)
        {
            return _context.VehiculeType.Any(e => e.Id == id);
        }
    }
}
