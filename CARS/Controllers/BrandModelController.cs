using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CARS.Data;
using CARS.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> CreateModel(Model model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public ActionResult Index(int? id)
        {
            dynamic mymodel = new ExpandoObject();
            if (id.HasValue)
            {
                mymodel.AllModels = GetModels(id.Value);
                mymodel.BrandName = _context.Brand.FirstOrDefault(x => x.Id == id).Name;
            }
            else
            {
                mymodel.BrandName = "All";
                mymodel.AllModels = GetModels();
            }
            mymodel.AllBrands = GetBrands();
            
            
            return View(mymodel);
        }
    
    }
}
