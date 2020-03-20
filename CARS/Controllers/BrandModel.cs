using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using CARS.Data;
using CARS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CARS.ViewModels
{
    public class BrandModel : Controller
    {

        private readonly AppDbContext _context;

        public BrandModel(AppDbContext context)
        {
            _context = context;
        }


        private IEnumerable<Brand> GetBrands()
        {
            return _context.Brand.ToList();
        }

        private IEnumerable<Model> GetModels()
        {
            return _context.CarModel.ToList();
        }

        public ActionResult Index(int? id)
        {
            if (id.HasValue)
            {

            }
            dynamic mymodel = new ExpandoObject();
            mymodel.AllModels = GetModels();
            mymodel.AllBrands = GetBrands();
            return View(mymodel);
        }
    
    }
}
