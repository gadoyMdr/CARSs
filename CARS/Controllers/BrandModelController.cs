using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CARS.Data;
using CARS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CARS.ViewModels
{
    public class BrandModelController : Controller
    {

        private readonly AppDbContext _context;

        public BrandModelController(AppDbContext context)
        {
            _context = context;
        }


        private IEnumerable<Brand> GetBrands()
        {
            return _context.Brand.ToList();
        }

        private IEnumerable<Model> GetModels(int id = 0)
        {
            
            if (id == 0)
            {
                return _context.CarModel.ToList();
            }
            else
            {
                return _context.CarModel.Where(x => x.BrandId == id).ToList();
            }
        }

        public async Task<IActionResult> CreateModel(string name, int brand)
        {
            Model car = new Model();
            car.Name = name;
            car.BrandId = brand;
            _context.Add(car);
            _context.SaveChanges();
            return RedirectToAction("Index", new { brand });
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.CarModel.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Name", model.BrandId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveEdit(int id, [Bind("Id,Name,BrandId")] Model model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Name", model.BrandId);
            return View(nameof(Index));
        }

        private bool ModelExists(int id)
        {
            return _context.CarModel.Any(e => e.Id == id);
        }

        public ActionResult Delete(int id)
        {

            var model = _context.CarModel
                .Include(m => m.Brand)
                .FirstOrDefault(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            _context.CarModel.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Index(int? id)
        {
            dynamic mymodel = new ExpandoObject();
            if (id.HasValue)
            {
                mymodel.AllModels = GetModels(id.Value);
                mymodel.BrandName = _context.Brand.FirstOrDefault(x => x.Id == id).Name;
                mymodel.BrandId = id;
            }
            else
            {
                mymodel.BrandName = "All";
                mymodel.AllModels = GetModels();
                mymodel.BrandId = 0;
            }
            mymodel.AllBrands = GetBrands();
            
            
            return View(mymodel);
        }
    
    }
}
